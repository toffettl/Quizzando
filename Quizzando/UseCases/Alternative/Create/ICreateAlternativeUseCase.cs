using Quizzando.Communication.Requests.Alternatives;
using Quizzando.Communication.Responses.Alternatives;

namespace Quizzando.UseCases.Alternative.Create
{
    public interface ICreateAlternativeUseCase
    {
        Task<AlternativeResponse> Execute(AlternativeRequest request);
    }
}
