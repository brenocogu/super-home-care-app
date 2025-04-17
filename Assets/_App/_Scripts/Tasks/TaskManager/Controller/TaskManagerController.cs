using System;
using System.Collections.Generic;
using UnityEngine;

namespace SuperHomeCare.Tasks
{
    public class TaskManagerController
    {
        public Action<Guid> OnTaskCompleted;
        readonly TaskManagerModel model;
        
        public TaskManagerController(TaskManagerModel model)
        {
            this.model = model;
        }

        public void CreateTask(string taskName, string taskDescription = "")
        {
            TaskData tasko = new TaskData(taskName, taskDescription);
        }

        public void CreateNewTask(TaskData taskData) => model.CreateNewTask(taskData);

        public HashSet<TaskData> GetPlayerActiveTasks()
        {
            return null;
        }

        public TaskData GetPlayerTask(Guid taskGuid)
        {
            return new TaskData();
        }

        public bool RemoveTask(Guid taskGuid)
        {
            return false;
        }

        public void ProgressTask(Guid taskGuid)
        {
            TaskData targetTask = GetPlayerTask(taskGuid);
            targetTask.MakeProgress(() => OnTaskCompleted?.Invoke(targetTask.TaskGUID));
        }
    }
}
