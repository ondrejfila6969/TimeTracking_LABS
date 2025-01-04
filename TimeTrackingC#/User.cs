using System;
using System.Collections.Generic;

namespace TimeTrackingLABS
{
    public class User
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public List<Task> Tasks { get; private set; }
        public Task CurrentTask { get; private set; }

        public int Age => DateTime.Now.Year - DateOfBirth.Year - (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);

        public User(string name, string email, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            if (CurrentTask != null)
            {
                StopTask(DateTime.Now);
            }

            foreach (var existingTask in Tasks)
            {
                if (task.StartTime < existingTask.EndTime && task.EndTime > existingTask.StartTime)
                {
                    throw new InvalidOperationException("Task overlaps with an existing task.");
                }
            }

            Tasks.Add(task);
        }
        public void StartTask(Task task)
        {
            if (CurrentTask != null)
            {
                StopTask(DateTime.Now);
            }

            foreach (var existingTask in Tasks)
            {
                if (task.StartTime < existingTask.EndTime && task.EndTime > existingTask.StartTime)
                {
                    throw new InvalidOperationException("Task overlaps with an existing task.");
                }
            }

            CurrentTask = task;
        }
        public void StopTask(DateTime endTime)
        {
            if (CurrentTask != null)
            {
                CurrentTask.Stop(endTime);
                CurrentTask = null;
            }
        }
    }
}