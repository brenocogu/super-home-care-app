using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SuperHomeCare.Tasks
{
    public class TaskManagerModel
    {
        public event Action OnTaskCreated;
        public event Action<Guid> OnTaskCompleted;
        
        HashSet<TaskData> PlayerActiveTasks => playerTasks.ToHashSet();
        
        List<TaskData> playerTasks;
        List<TaskData> completedTasks;
        
        public void CreateNewTask(TaskData taskToCreate)
        {
            if (completedTasks.Contains(taskToCreate))
                completedTasks.Remove(taskToCreate);
            
            playerTasks.Add(taskToCreate);
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
    }
}
