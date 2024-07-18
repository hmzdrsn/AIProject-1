using AIProject.Domain.Entities;

namespace AIProject.Application.Common.Interfaces
{
    public interface IPromptService
    {
        Task<Prompt> GetById(string id , CancellationToken cancellationToken);
        Task<Prompt> CreatePrompt(Prompt request, CancellationToken cancellationToken);
        bool IsPromptIdValid(string promptId);
    }
}
