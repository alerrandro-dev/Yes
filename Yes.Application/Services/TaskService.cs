using FluentValidation;
using Mapster;
using Yes.Domain.Entities;
using Yes.Domain.Repositories;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.Task;
using Yes.Shared.Responses;
using Yes.Shared.Results;
using Yes.Shared.Results.Task;
using Yes.Shared.Services;

namespace Yes.Application.Services;

public class TaskService(ITaskRepository repository, IToDoListRepository toDoListRepository, IValidator<AddTaskRequest> addValidator,
    IValidator<UpdateTaskRequest> updateValidator) : ITaskService
{
    public async Task<AddTaskResult> AddAsync(AddTaskRequest request)
    {
        var validationResult = await addValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var existsToDoListWithId = await toDoListRepository.ExistsWithIdAsync(request.ToDoListId.Value);
        if (!existsToDoListWithId) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), request.ToDoListId);

        var existsWithNameFromToDoListWithId = await repository.ExistsWithNameFromToDoListWithIdAsync(request.Name, request.ToDoListId.Value);
        if (existsWithNameFromToDoListWithId) return new EntityFromOwnerEntityAlreadyExistsError(nameof(TaskEntity), nameof(TaskEntity.Name), request.Name,
            nameof(ToDoListEntity), nameof(ToDoListEntity.Id), request.ToDoListId);

        var entity = request.Adapt<TaskEntity>();

        await repository.AddAsync(entity);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<TaskResponse>();
        return response;
    }

    public async Task<DeleteTaskResult> DeleteByIdAsync(Guid id)
    {
        bool deleted = await repository.DeleteByIdAsync(id);
        if (!deleted) return new EntityNotFoundError(nameof(TaskEntity), nameof(TaskEntity.Id), id);

        return new Success();
    }

    public async Task<GetTaskResult> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(TaskEntity), nameof(TaskEntity.Id), id);

        var reponse = entity.Adapt<TaskResponse>();
        return reponse;
    }

    public async Task<UpdateTaskResult> UpdateByIdAsync(Guid id, UpdateTaskRequest request)
    {
        var validationResult = await updateValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(TaskEntity), nameof(TaskEntity.Id), id);

        var existsWithNameFromToDoListWithId = await repository.ExistsWithNameFromToDoListWithIdAsync(request.Name, entity.ToDoListId);
        if (existsWithNameFromToDoListWithId) return new EntityFromOwnerEntityAlreadyExistsError(nameof(TaskEntity), nameof(TaskEntity.Name), request.Name,
            nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);

        request.Adapt(entity);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<TaskResponse>();
        return response;
    }
}
