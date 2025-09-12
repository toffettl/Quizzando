using Quizzando.Communication.Responses.Alternatives;

namespace Quizzando.UseCases.Alternative.Get.ById
{
    public interface IGetAlternativeByIdUseCase
    {
        Task<AlternativeResponse> Execute(Guid id);
    }
}
