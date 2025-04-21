using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SuperHomeCare.Tasks
{
    public class TaskManagerModel
    {
        public event Action<TaskData> OnTaskCreated;
        public event Action<Guid> OnTaskCompleted;
        
        public HashSet<TaskData> PlayerActiveTasks => playerTasks.ToHashSet();
        
        List<TaskData> playerTasks = new();
        List<TaskData> completedTasks = new();
        
        public void CreateNewTask(TaskData taskToCreate)
        {
            if (completedTasks.Contains(taskToCreate))
                completedTasks.Remove(taskToCreate);
            
            playerTasks.Add(taskToCreate);
            OnTaskCreated?.Invoke(taskToCreate);
        }

        public void CompleteATask(Guid taskGuid)
        {
            TaskData found = playerTasks.FirstOrDefault(x => x.TaskGUID == taskGuid);
            if (found == null)
            {
                Debug.LogError("Trying to complete a task that does not exists");
                return;
            }

            playerTasks.Remove(found);
            completedTasks.Add(found);
            
            OnTaskCompleted?.Invoke(found.TaskGUID);
        }

        public bool TryGetTaskFromGuid(Guid taskGuid, out TaskData foundTask)
        {
            foundTask = playerTasks.FirstOrDefault(x => x.TaskGUID == taskGuid);
            return foundTask != default;
        }
    }
}
