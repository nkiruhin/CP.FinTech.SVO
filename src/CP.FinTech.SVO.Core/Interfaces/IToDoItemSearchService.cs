using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using CP.FinTech.SVO.Core.ProjectAggregate;

namespace CP.FinTech.SVO.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
        Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
    }
}
