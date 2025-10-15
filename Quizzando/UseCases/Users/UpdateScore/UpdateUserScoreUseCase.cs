using Quizzando.DataAccess.Repositories;
using Quizzando.DataAccess.Repositories.UserRepositories;

namespace Quizzando;

public class UpdateUserScoreUseCase : IUpdateUserScoreUseCase
{
    private readonly IUserReadOnlyRepository _readRepo;
    private readonly IUserUpdateOnlyRepository _updateRepo;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserScoreUseCase(
        IUserReadOnlyRepository readRepo,
        IUserUpdateOnlyRepository updateRepo,
        IUnitOfWork unitOfWork)
    {
        _readRepo = readRepo;
        _updateRepo = updateRepo;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(Guid id, int newScore)
    {
        var user = await _readRepo.GetUserById(id);

        if (user == null)
            throw new KeyNotFoundException("Usuário não encontrado.");

        user.Score += newScore;

        _updateRepo.Update(user);
        await _unitOfWork.Commit();
    }
}
