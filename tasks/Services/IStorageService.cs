using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tasks.Services
{
    public interface IStorageService
    {
        Task<(bool IsSuccess, Exception exception)> InsertTaskAsync(Entity.Task task);

        Task<List<Entity.Task>> GetTasksAsync(
            Guid id = default(Guid),
            string title = default(string),
            string description = default(string),
            string tags = default(string),
            Entity.ETaskPriority? priority = null,
            Entity.ETaskRepeat? repeat= null,
            Entity.ETaskStatus? status = null,
            DateTimeOffset onADay = default(DateTimeOffset),
            DateTimeOffset atATime = default(DateTimeOffset),
            string location = default(string),
            string url = default(string));
        
        Task<(bool isSuccess, Exception exception)> UpdateTaskAsync(Entity.Task task);
    }
}