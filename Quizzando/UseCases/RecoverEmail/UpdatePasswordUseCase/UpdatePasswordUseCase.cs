
using AutoMapper;
using Quizzando.Communication.Requests.User;
using Quizzando.DataAccess.Repositories.UserRepositories;
using Quizzando.DataAccess.Repositories;
using Quizzando.Exception.ExceptionsBase;
using Quizzando.Exception;
using Quizzando.UseCases.Users.Update;
using Quizzando.Security.Cryptography;
using Microsoft.AspNetCore.Identity.Data;
using Quizzando.Communication.Requests.Email;
using Quizzando.UseCases.Users.Register;
using FluentValidation;

namespace Quizzando.UseCases.RecoverEmail.UpdatePasswordUseCase;

public class UpdatePasswordUseCase : IUpdatePasswordUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUserUpdateOnlyRepository _userUpdateOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordEncripter _passwordEncripter;

    public UpdatePasswordUseCase(
        IUserReadOnlyRepository userReadOnlyRepository,
        IUserUpdateOnlyRepository userUpdateOnlyRepository,
        IUnitOfWork unitOfWork,
        IPasswordEncripter passwordEncripter)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _userUpdateOnlyRepository = userUpdateOnlyRepository;
        _unitOfWork = unitOfWork;
        _passwordEncripter = passwordEncripter;
    }

    public async Task Execute(Guid userId, string newPassword)
    {
        await Validate(newPassword);

        var user = await _userReadOnlyRepository.GetUserById(userId);
        if (user == null)
            throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);

        user.password = _passwordEncripter.Encrypt(newPassword);

        _userUpdateOnlyRepository.Update(user);
        await _unitOfWork.Commit();
    }

    private async Task Validate(string newPassword)
    {
        var validator = new InlineValidator<ResetPassworRequest>();
        validator.RuleFor(r => r.NewPassword).SetValidator(new PasswordValidator<ResetPassworRequest>());

        var tempRequest = new ResetPassworRequest
        {
            NewPassword = newPassword,
            UserId = Guid.Empty,
            Code = "",   
            Token = ""
        };

        var result = validator.Validate(tempRequest);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }

        await Task.CompletedTask;
    }
}
