namespace Quizzando;

public interface IUpdateUserScoreUseCase
{
    Task Execute(Guid id, int newScore);
}
