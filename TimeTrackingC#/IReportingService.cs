namespace TimeTrackingLABS
{
    public interface IReportingService
    {
        void PrintAllTasks(User user);
        void PrintTasksByProject(User user, Project project);
        void PrintTasksByDurationRange(User user, TimeSpan minimalDuration, TimeSpan maximalDuration);
        void PrintTotalTimeInfo(User user);
    }
}