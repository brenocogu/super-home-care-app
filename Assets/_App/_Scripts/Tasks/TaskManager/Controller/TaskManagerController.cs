using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace SuperHomeCare.Tasks
{
    public class TaskManagerController: IStartable
    {
        public event Action<Guid> OnTaskCompleted;
        public event Action<TaskData> OnTaskCreated;
        
        readonly TaskManagerModel model;
        
        public TaskManagerController(TaskManagerModel model)
        {
            this.model = model;
        }

        public void Start()
        {
            model.OnTaskCreated += data => OnTaskCreated?.Invoke(data);
        }

        public void CreateTask(string taskName, string taskDescription = "")
        {
            TaskData tasko = new TaskData(taskName, taskDescription);
            CreateNewTask(tasko);
        }

        public void CreateNewTask(TaskData taskData) => model.CreateNewTask(taskData);

        public HashSet<TaskData> GetPlayerActiveTasks() => model.PlayerActiveTasks;

        public TaskData GetPlayerTask(Guid taskGuid)
        {
            if (model.TryGetTaskFromGuid(taskGuid, out TaskData found))
                return found;
            
            return null;
        }

        public void RemoveTask(Guid taskGuid) => model.CompleteATask(taskGuid);

        public void ProgressTask(Guid taskGuid)
        {
            TaskData targetTask = GetPlayerTask(taskGuid);
            targetTask.MakeProgress(() => OnTaskCompleted?.Invoke(targetTask.TaskGUID));
            RemoveTask(taskGuid);
        }
    }
}
