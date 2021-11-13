namespace tasks.Mapper
{
    public static class ModelEntityMapper
    {
        public static Entity.Task ToTaskEntity(this Model.NewTask newTask)
        {
            return new Entity.Task(
                title: newTask.Title,
                description: newTask.Description,
                tags: newTask.Tags is null ? string.Empty : string.Join(',', newTask.Tags),
                location: newTask.Location is null ? string.Empty : string.Format($"{newTask.Location.Latitude},{newTask.Location.Longitude}"),
                atATime: newTask.AtATime,
                onADay: newTask.OnADay,
                repeat: newTask.Repeat.ToEntityETaskRepeat(),
                status: newTask.Status.ToEntityETaskStatus(),
                priority: newTask.Priority.ToEntityETaskPriority(),
                url: newTask.Url
            );
        }

        public static Entity.Task ToTaskEntity(this Model.UpdatedTask task)
        {
            return new Entity.Task(
                title: task.Title,
                description: task.Description,
                tags: task.Tags is null ? string.Empty : string.Join(',', task.Tags),
                location: task.Location is null ? string.Empty : string.Format($"{task.Location.Latitude},{task.Location.Longitude}"),
                atATime: task.AtATime,
                onADay: task.OnADay,
                repeat: task.Repeat.ToEntityETaskRepeat(),
                status: task.Status.ToEntityETaskStatus(),
                priority: task.Priority.ToEntityETaskPriority(),
                url: task.Url)
                {
                    Id = task.Id
                };
        }
    }
}