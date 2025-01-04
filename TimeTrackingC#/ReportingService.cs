namespace TimeTrackingLABS
{
    public class ReportingService : IReportingService
    {
        public void PrintAllTasks(User user)
        {
            Console.WriteLine($"User: {user.Name}, Age: {user.Age}, Email: {user.Email}");
            foreach (var task in user.Tasks)
            {
                Console.WriteLine($"Task: {task.Description}, Project: {task.Project}, Duration: {task.Duration}");
            }
        }

        public void PrintTasksByProject(User user, Project project)
        {
            Console.WriteLine($"User: {user.Name}, Age: {user.Age}, Email: {user.Email}");
            foreach (var task in user.Tasks.Where(t => t.Project == project))
            {
                Console.WriteLine($"Task: {task.Description}, Project: {task.Project}, Duration: {task.Duration}");
            }
        }

        public void PrintTasksByDurationRange(User user, TimeSpan minimalDuration, TimeSpan maximalDuration)
        {
            Console.WriteLine($"User: {user.Name}, Age: {user.Age}, Email: {user.Email}");
            foreach (var task in user.Tasks.Where(t => t.Duration >= minimalDuration && t.Duration <= maximalDuration))
            {
                Console.WriteLine($"Task: {task.Description}, Project: {task.Project}, Duration: {task.Duration}");
            }
        }

        public void PrintTotalTimeInfo(User user)
        {
            Console.WriteLine($"User: {user.Name}, Age: {user.Age}, Email: {user.Email}");
            var totalDuration = user.Tasks.Sum(t => t.Duration.TotalSeconds);
            Console.WriteLine($"Total Time Spent: {totalDuration} seconds");
        }
    }
}