using Quizzando.Communication.Requests.Alternatives;

namespace Quizzando.UseCases.Alternative.Update
{
    public interface IUpdateAlternativeUseCase
    {
        Task Execute(Guid id, AlternativeRequest request);
    }
}
