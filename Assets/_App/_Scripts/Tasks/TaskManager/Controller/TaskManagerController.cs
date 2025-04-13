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
        
        public void CreateNewTask(){ }

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
            Debug.Log("Progressing!!");
            TaskData targetTask = GetPlayerTask(taskGuid);
            targetTask.MakeProgress(() => OnTaskCompleted?.Invoke(targetTask.TaskGUID));
        }
    }
}
