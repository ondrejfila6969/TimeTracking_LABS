using System;
using System.Collections.Generic;

namespace TimeTrackingLABS
{
    public class Task
    {
        public string Description { get; private set; }
        public Project Project { get; private set; }
        public List<string> Tags { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }

        public TimeSpan Duration => EndTime.HasValue ? EndTime.Value - StartTime : DateTime.Now - StartTime;

        public Task(string description, Project project, List<string> tags, DateTime startTime)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or whitespace.");
            }

            if (tags == null || tags.Count == 0 || tags.Count > 10)
            {
                throw new ArgumentException("Tags cannot be empty or exceed 10 tags.");
            }

            var bannedTags = new List<string> { "test", "demo", "príklad", "dummy" };
            foreach (var tag in tags)
            {
                if (bannedTags.Contains(tag.ToLower()))
                {
                    throw new ArgumentException($"Tag '{tag}' is not allowed.");
                }
            }

            Description = description;
            Project = project;
            Tags = tags;
            StartTime = startTime;
            EndTime = null;
        }

        public void Stop(DateTime endTime)
        {
            EndTime = endTime;
        }
    }
}