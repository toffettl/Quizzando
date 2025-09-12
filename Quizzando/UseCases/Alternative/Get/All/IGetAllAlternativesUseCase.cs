using Quizzando.Communication.Responses.Alternatives;

namespace Quizzando.UseCases.Alternative.Get.All
{
    public interface IGetAllAlternativesUseCase
    {
        Task<AlternativeResponses> Execute();
    }
}
