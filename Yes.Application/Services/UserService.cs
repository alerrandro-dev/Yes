using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Yes.Domain.Entities;
using Yes.Domain.Repositories;
using Yes.Shared.Contexts;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.User;
using Yes.Shared.Responses;
using Yes.Shared.Results;
using Yes.Shared.Results.User;
using Yes.Shared.Services;

namespace Yes.Application.Services;

public class UserService(IUserRepository repository, IUserContext context, IValidator<AddUserRequest> addValidator,
    [FromKeyedServices("FullUpdateUserValidator")] IValidator<UpdateUserRequest> fullUpdateValidator,
    [FromKeyedServices("PartialUpdateUserValidator")] IValidator<UpdateUserRequest> partialUpdateValidator) : IUserService
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

    public async Task<UpdateUserResult> FullUpdateAsync(UpdateUserRequest request)
    {
        var validationResult = await fullUpdateValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var entity = await repository.GetByIdAsync(context.Id);
        if (entity is null) return new EntityNotFoundError(nameof(UserEntity), nameof(UserEntity.Id), context.Id);

        var existsWithEmail = await repository.ExistsWithEmailAsync(request.Email);
        if (existsWithEmail) return new EntityAlreadyExistsError(nameof(UserEntity), nameof(UserEntity.Email), request.Email);

        request.Adapt(entity);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<UserResponse>();
        return response;
    }

    public async Task<DeleteUserResult> DeleteAsync()
    {
        var deleted = await repository.DeleteByIdAsync(context.Id);
        if (!deleted) return new EntityNotFoundError(nameof(UserEntity), nameof(UserEntity.Id), context.Id);

        return new Success();
    }

    public async Task<GetUserResult> GetAsync()
    {
        var entity = await repository.GetByIdAsync(context.Id);
        if (entity is null) return new EntityNotFoundError(nameof(UserEntity), nameof(UserEntity.Id), context.Id);

        var response = entity.Adapt<UserResponse>();
        return response;
    }

    public async Task<UpdateUserResult> PartialUpdateAsync(UpdateUserRequest request)
    {
        var validationResult = await partialUpdateValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var entity = await repository.GetByIdAsync(context.Id);
        if (entity is null) return new EntityNotFoundError(nameof(UserEntity), nameof(UserEntity.Id), context.Id);

        if (request.Email is not null)
        {
            var existsWithEmail = await repository.ExistsWithEmailAsync(request.Email);
            if (existsWithEmail) return new EntityAlreadyExistsError(nameof(UserEntity), nameof(UserEntity.Email), request.Email);
        }

        var typeAdapterConfig = new TypeAdapterConfig();
        typeAdapterConfig.NewConfig<UpdateUserRequest, UserEntity>()
            .IgnoreNullValues(true);

        request.Adapt(entity, typeAdapterConfig);
        await repository.SaveChangesAsync();

        var response = entity.Adapt<UserResponse>();
        return response;
    }
}
