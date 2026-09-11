using FluentValidation;
using Mapster;
using Yes.Domain.Entities;
using Yes.Domain.Repositories;
using Yes.Shared.Contexts;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.ToDoList;
using Yes.Shared.Responses;
using Yes.Shared.Results;
using Yes.Shared.Results.ToDoList;
using Yes.Shared.Services;

namespace Yes.Application.Services;

public class ToDoListService(IToDoListRepository repository, IUserRepository userRepository, IUserContext userContext,
    IValidator<AddToDoListRequest> addValidator, IValidator<UpdateToDoListRequest> updateValidator) : IToDoListService
{
    public async Task<AddToDoListResult> AddAsync(AddToDoListRequest request)
    {
        var validationResult = await addValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var existsUserWithId = await userRepository.ExistsUserWithIdAsync(userContext.Id);
        if (!existsUserWithId) return new EntityNotFoundError(nameof(UserEntity), nameof(UserEntity.Id), userContext.Id);

        var existsWithNameFromUserWithId = await repository.ExistsWithNameFromUserWithIdAsync(request.Name, userContext.Id);
        if (existsWithNameFromUserWithId) return new EntityFromOwnerEntityAlreadyExistsError(nameof(ToDoListEntity), nameof(ToDoListEntity.Name),
            request.Name, nameof(UserEntity), nameof(UserEntity.Id), userContext.Id);

        var entity = request.Adapt<ToDoListEntity>();
        entity.UserId = userContext.Id;

        await repository.AddAsync(entity);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<ToDoListResponse>();
        return response;
    }

    public async Task<DeleteToDoListResult> DeleteByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), id);
        if (entity.UserId != userContext.Id) return new EntityBelongToOtherUserError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), id);

        await repository.DeleteAsync(entity);
        await repository.SaveChangesAsync();

        return new Success();
    }

    public async Task<GetToDoListResult> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), id);
        if (entity.UserId != userContext.Id) return new EntityBelongToOtherUserError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), id);

        var response = entity.Adapt<ToDoListResponse>();
        return response;
    }

    public async Task<UpdateToDoListResult> FullUpdateByIdAsync(Guid id, UpdateToDoListRequest request)
    {
        var validationResult = await updateValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), id);
        if (entity.UserId != userContext.Id) return new EntityBelongToOtherUserError(nameof(ToDoListEntity), nameof(ToDoListEntity.Id), id);

        var existsWithNameFromUserWithId = await repository.ExistsWithNameFromUserWithIdAsync(request.Name, entity.UserId);
        if (existsWithNameFromUserWithId) return new EntityFromOwnerEntityAlreadyExistsError(nameof(ToDoListEntity), nameof(ToDoListEntity.Name),
            request.Name, nameof(UserEntity), nameof(UserEntity.Id), entity.UserId);

        request.Adapt(entity);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<ToDoListResponse>();
        return response;
    }
}
