using FluentValidation;
using Mapster;
using Yes.Domain.Entities;
using Yes.Domain.Repositories;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests;
using Yes.Shared.Responses;
using Yes.Shared.Results;
using Yes.Shared.Services;

namespace Yes.Application.Services;

public class AuthenticationService(IUserRepository userRepository, TokenProviderService tokenProviderService, IValidator<RegisterRequest> registerValidator, IValidator<LoginRequest> loginValidator) : IAuthenticationService
{
    public async Task<LoginResult> LoginAsync(LoginRequest request)
    {
        var validationResult = await loginValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var entity = await userRepository.GetByEmailAsync(request.Email);
        if (entity is null) return new EntityNotFoundError(nameof(UserEntity), nameof(UserEntity.Email), request.Email);

        var correctPassword = entity.Password == request.Password;
        if (!correctPassword) return new IncorrectPasswordError(request.Password);

        var token = tokenProviderService.ProvideToken(entity.Id);

        var response = new LoginResponse(token);
        return response;
    }

    public async Task<ResgisterResult> RegisterAsync(RegisterRequest request)
    {
        var validationResult = await registerValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return new ValidationError(validationResult.ErrorsToStringArray());

        var existsWithEmail = await userRepository.ExistsWithEmailAsync(request.Email);
        if (existsWithEmail) return new EntityAlreadyExistsError(nameof(UserEntity), nameof(UserEntity.Email), request.Email);

        var entity = request.Adapt<UserEntity>();

        await userRepository.AddAsync(entity);
        await userRepository.SaveChangesAsync();

        var response = entity.Adapt<RegisterResponse>();
        return response;
    }


}
