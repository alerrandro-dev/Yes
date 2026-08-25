using FluentValidation;
using Mapster;
using Yes.Domain.Entities;
using Yes.Domain.Repositories;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.ToDoList;
using Yes.Shared.Responses;
using Yes.Shared.Results;
using Yes.Shared.Results.ToDoList;
using Yes.Shared.Services;

namespace Yes.Application.Services;

public class ToDoListService(IToDoListRepository repository, IUserRepository userRepository, IValidator<AddToDoListRequest> addValidator,
    IValidator<UpdateToDoListRequest> updateValidator) : IToDoListService
{
    public async Task<AddToDoListResult> AddAsync(AddToDoListRequest request)
    {
        var validationResult = addValidator.Validate(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var existsUserWithId = await userRepository.ExistsUserWithIdAsync(request.UserId.Value);
        if (!existsUserWithId) return new EntityNotFoundError(nameof(UserEntity), nameof(UserEntity.Id), request.UserId);

        var existsWithNameFromUserWithId = await repository.ExistsWithNameFromUserWithIdAsync(request.Name, request.UserId.Value);
        if (existsWithNameFromUserWithId) return new EntityFromOwnerEntityAlreadyExistsError(nameof(ToDoListEntity), nameof(ToDoListEntity.Name),
            request.Name, nameof(UserEntity), nameof(UserEntity.Id), request.UserId.Value);

        var entity = request.Adapt<ToDoListEntity>();

        await repository.AddAsync(entity);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<ToDoListResponse>();
        return response;
    }

    public async Task<DeleteToDoListResult> DeleteByIdAsync(Guid id)
    {
        var deleted = await repository.DeleteByIdAsync(id);
        if (!deleted) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), id);

        return new Success();
    }

    public async Task<GetToDoListResult> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), id);

        var response = entity.Adapt<ToDoListResponse>();
        return response;
    }

    public async Task<UpdateToDoListResult> UpdateByIdAsync(Guid id, UpdateToDoListRequest request)
    {
        var validationResult = updateValidator.Validate(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), id);

        var existsWithNameFromUserWithId = await repository.ExistsWithNameFromUserWithIdAsync(request.Name, entity.UserId);
        if (existsWithNameFromUserWithId) return new EntityFromOwnerEntityAlreadyExistsError(nameof(ToDoListEntity), nameof(ToDoListEntity.Name),
            request.Name, nameof(UserEntity), nameof(UserEntity.Id), entity.UserId);

        request.Adapt(entity);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<ToDoListResponse>();
        return response;
    }
}
