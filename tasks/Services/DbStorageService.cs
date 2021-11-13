using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using tasks.Data;

namespace tasks.Services
{
    public class DbStorageService : IStorageService
    {
        private readonly TaskDbContext _context;
        private readonly ILogger<DbStorageService> _logger;

        public DbStorageService(TaskDbContext context, ILogger<DbStorageService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Entity.Task>> GetTasksAsync(
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
            string url = default(string))
        {
            var tasks = _context.Tasks.AsNoTracking();

            if(id != default(Guid))
            {
                tasks = tasks.Where(t => t.Id == id);
            }

            if(title != default(string))
            {
                tasks = tasks.Where(t => t.Title.ToLower().Equals(title.ToLower()) 
                            || t.Title.ToLower().Contains(title.ToLower()));
            }

            if(tags != default(string))
            {
                // TO-DO: optimize
                tasks = tasks.Where(t => t.Tags.ToLower().Equals(tags.ToLower()));
            }

            if(priority.HasValue)
            {
                tasks = tasks.Where(t => t.Priority == priority.Value);
            }

            if(status.HasValue)
            {
                tasks = tasks.Where(t => t.Status == status.Value);
            }

            if(repeat.HasValue)
            {
                tasks = tasks.Where(t => t.Repeat == repeat.Value);
            }

            if(onADay != default(DateTimeOffset))
            {
                tasks = tasks.Where(t => t.OnADay == onADay);
            }

            if(atATime != default(DateTimeOffset))
            {
                tasks = tasks.Where(t => t.AtATime == atATime);
            }

            if(location != default(string))
            {
                tasks = tasks.Where(t => t.Location == location);
            }

            if(url != default(string))
            {
                tasks = tasks.Where(t => t.Url == url);
            }

            return await tasks.ToListAsync();
        }

        public async Task<(bool IsSuccess, Exception exception)> InsertTaskAsync(Entity.Task task)
        {
            try
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Task inserted in DB: {task.Id}");

                return (true, null);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"Inserting task to DB failed: {e.Message}", e);
                return (false, e);
            }
        }

        public async Task<(bool isSuccess, Exception exception)> UpdateTaskAsync(Entity.Task task)
        {
            try
            {
                if(await _context.Tasks.AnyAsync(t => t.Id == task.Id))
                {
                    _context.Tasks.Update(task);
                    await _context.SaveChangesAsync();

                    return (true, null);
                }
                else
                {
                    return (false, new Exception($"Task with given ID: {task.Id} doesnt exist!"));
                }
            }
            catch(Exception e)
            {
                return (false, e);
            }
        }
    }
}