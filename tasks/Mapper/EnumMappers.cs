namespace tasks.Mapper
{
    public static class EnumMappers
    {
        public static Entity.ETaskPriority ToEntityETaskPriority(this Model.ETaskPriority? priority)
        {
            return priority switch
            {
                Model.ETaskPriority.High => Entity.ETaskPriority.High,
                Model.ETaskPriority.Mid => Entity.ETaskPriority.Mid,
                Model.ETaskPriority.Low => Entity.ETaskPriority.Low,
                _ => Entity.ETaskPriority.None,
            };
        }

        public static Entity.ETaskStatus ToEntityETaskStatus(this Model.ETaskStatus? status)
        {
            return status switch
            {
                Model.ETaskStatus.Completed => Entity.ETaskStatus.Completed,
                Model.ETaskStatus.InProgress => Entity.ETaskStatus.InProgress,
                Model.ETaskStatus.Postponed => Entity.ETaskStatus.Postponed,
                _ => Entity.ETaskStatus.None,
            };
        }

        public static Entity.ETaskRepeat ToEntityETaskRepeat(this Model.ETaskRepeat? repeat)
        {
            return repeat switch
            {
                Model.ETaskRepeat.Daily => Entity.ETaskRepeat.Daily,
                Model.ETaskRepeat.Hourly => Entity.ETaskRepeat.Hourly,
                Model.ETaskRepeat.Monthly => Entity.ETaskRepeat.Monthly,
                Model.ETaskRepeat.Weekly => Entity.ETaskRepeat.Weekly,
                Model.ETaskRepeat.Yearly => Entity.ETaskRepeat.Yearly,
                _ => Entity.ETaskRepeat.Never
            };
        }
    }
}