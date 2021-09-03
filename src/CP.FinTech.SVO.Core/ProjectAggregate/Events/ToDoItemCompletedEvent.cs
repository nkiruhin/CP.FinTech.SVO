using CP.FinTech.SVO.Core.ProjectAggregate;
using CP.FinTech.SVO.SharedKernel;

namespace CP.FinTech.SVO.Core.ProjectAggregate.Events
{
    public class ToDoItemCompletedEvent : BaseDomainEvent
    {
        public ToDoItem CompletedItem { get; set; }

        public ToDoItemCompletedEvent(ToDoItem completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}