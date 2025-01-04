using System;
using System.Collections.Generic;
using System.Threading;

namespace TimeTrackingLABS
{
    public class Program
    {
        static void Main(string[] args)
        {
            var user = new User("Jiří Novák", "jirinovak@gmail.com", new DateTime(1990, 5, 10));
            var task1 = new Task("Task 1", Project.ProjectA, new List<string> { "work", "coding" }, DateTime.Now);
            user.AddTask(task1);

            Thread.Sleep(2000);

            var task2 = new Task("Task 2", Project.ProjectB, new List<string> { "meeting", "admin" }, DateTime.Now);
            user.AddTask(task2);

            user.StartTask(task1);

            Thread.Sleep(2000);
            user.StopTask(DateTime.Now);

            var reportingService = new ReportingService();

            reportingService.PrintAllTasks(user);
            Console.WriteLine();

            reportingService.PrintTasksByProject(user, Project.ProjectA);
            Console.WriteLine();

            reportingService.PrintTasksByDurationRange(user, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3));
            Console.WriteLine();

            reportingService.PrintTotalTimeInfo(user);
        }
    }
}