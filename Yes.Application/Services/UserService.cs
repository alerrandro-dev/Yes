using FluentValidation;
using Mapster;
using Yes.Domain.Entities;
using Yes.Domain.Repositories;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.User;
using Yes.Shared.Responses;
using Yes.Shared.Results;
using Yes.Shared.Results.User;
using Yes.Shared.Services;

namespace Yes.Application.Services;

public class UserService(IUserRepository repository, IValidator<AddUserRequest> addValidator, IValidator<UpdateUserRequest> updateValidator) : IUserService
{
    public async Task<AddUserResult> AddAsync(AddUserRequest request)
    {
        var validationResult = await addValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var existsWithEmail = await repository.ExistsWithEmailAsync(request.Email);
        if (existsWithEmail) return new EntityAlreadyExistsError(nameof(UserEntity), nameof(UserEntity.Email), request.Email);

        var entity = request.Adapt<UserEntity>();

        await repository.AddAsync(entity);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<UserResponse>();
        return response;
    }

    public async Task<UpdateUserResult> UpdateByIdAsync(Guid id, UpdateUserRequest request)
    {
        var validationResult = await updateValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(UserEntity), nameof(UserEntity.Id), id);

        var existsWithEmail = await repository.ExistsWithEmailAsync(request.Email);
        if (existsWithEmail) return new EntityAlreadyExistsError(nameof(UserEntity), nameof(UserEntity.Email), request.Email);

        request.Adapt(entity);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<UserResponse>();
        return response;
    }

    public async Task<DeleteUserResult> DeleteByIdAsync(Guid id)
    {
        var deleted = await repository.DeleteByIdAsync(id);
        if (!deleted) return new EntityNotFoundError(nameof(UserEntity), nameof(UserEntity.Id), id);

        return new Success();
    }

    public async Task<GetUserResult> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return new EntityNotFoundError(nameof(UserEntity), nameof(UserEntity.Id), id);

        var response = entity.Adapt<UserResponse>();
        return response;
    }
}
