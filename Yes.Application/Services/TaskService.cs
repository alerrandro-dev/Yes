using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Yes.Domain.Entities;
using Yes.Domain.Repositories;
using Yes.Shared.Contexts;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.Task;
using Yes.Shared.Responses;
using Yes.Shared.Results;
using Yes.Shared.Results.Task;
using Yes.Shared.Services;

namespace Yes.Application.Services;

public class TaskService(ITaskRepository repository, IToDoListRepository toDoListRepository, IUserContext userContext,
    IValidator<AddTaskRequest> addValidator, IServiceProvider serviceProvider) : ITaskService
{
    private IValidator<UpdateTaskRequest> _fullUpdateValidator => serviceProvider
        .GetRequiredKeyedService<IValidator<UpdateTaskRequest>>("FullUpdateTaskValidator");
    private IValidator<UpdateTaskRequest> _partialUpdateValidator => serviceProvider
        .GetRequiredKeyedService<IValidator<UpdateTaskRequest>>("PartialUpdateTaskValidator");
    private TypeAdapterConfig _typeAdapterConfig => serviceProvider
        .GetRequiredKeyedService<TypeAdapterConfig>("UpdateTaskRequestToTaskEntityTypeAdapterConfig");

    public async Task<AddTaskResult> AddAsync(AddTaskRequest request)
    {
        var validationResult = await addValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var toDoList = await toDoListRepository.GetByIdAsync(request.ToDoListId.Value);
        if (toDoList is null) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), request.ToDoListId);
        if (toDoList.UserId != userContext.Id) return new EntityBelongToOtherUserError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), request.ToDoListId);

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
        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(TaskEntity), nameof(TaskEntity.Id), id);

        var toDoList = await toDoListRepository.GetByIdAsync(entity.ToDoListId);
        if (toDoList is null) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);
        if (toDoList.UserId != userContext.Id) return new EntityBelongToOtherUserError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);

        await repository.DeleteAsync(entity);
        await repository.SaveChangesAsync();

        return new Success();
    }

    public async Task<GetTaskResult> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(TaskEntity), nameof(TaskEntity.Id), id);

        var toDoList = await toDoListRepository.GetByIdAsync(entity.ToDoListId);
        if (toDoList is null) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);
        if (toDoList.UserId != userContext.Id) return new EntityBelongToOtherUserError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);

        var reponse = entity.Adapt<TaskResponse>();
        return reponse;
    }

    public async Task<UpdateTaskResult> FullUpdateByIdAsync(Guid id, UpdateTaskRequest request)
    {
        var validationResult = await _fullUpdateValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(TaskEntity), nameof(TaskEntity.Id), id);

        var toDoList = await toDoListRepository.GetByIdAsync(entity.ToDoListId);
        if (toDoList is null) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);
        if (toDoList.UserId != userContext.Id) return new EntityBelongToOtherUserError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);

        var existsWithNameFromToDoListWithId = await repository.ExistsWithNameFromToDoListWithIdAsync(request.Name, entity.ToDoListId);
        if (existsWithNameFromToDoListWithId) return new EntityFromOwnerEntityAlreadyExistsError(nameof(TaskEntity), nameof(TaskEntity.Name), request.Name,
            nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);

        request.Adapt(entity);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<TaskResponse>();
        return response;
    }

    public async Task<UpdateTaskResult> PartialUpdateByIdAsync(Guid id, UpdateTaskRequest request)
    {
        var validationResult = await _partialUpdateValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(TaskEntity), nameof(TaskEntity.Id), id);

        var toDoList = await toDoListRepository.GetByIdAsync(entity.ToDoListId);
        if (toDoList is null) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);
        if (toDoList.UserId != userContext.Id) return new EntityBelongToOtherUserError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);

        if (request.Name is not null)
        {
            var existsWithNameFromToDoListWithId = await repository.ExistsWithNameFromToDoListWithIdAsync(request.Name, entity.ToDoListId);
            if (existsWithNameFromToDoListWithId) return new EntityFromOwnerEntityAlreadyExistsError(nameof(TaskEntity), nameof(TaskEntity.Name), request.Name,
                nameof(ToDoListEntity), nameof(ToDoListEntity.Id), entity.ToDoListId);
        }

        request.Adapt(entity, _typeAdapterConfig);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<TaskResponse>();
        return response;
    }
}
