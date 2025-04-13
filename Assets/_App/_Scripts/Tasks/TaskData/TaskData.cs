using System;

namespace SuperHomeCare.Tasks
{
    [Serializable]
    public class TaskData
    {
        public readonly Guid TaskGUID;
        public readonly string TaskName;
        public readonly string TaskDescription;

        public TaskData()
        {
            TaskGUID = new Guid();
            TaskName = "New Task";
            TaskDescription = "Add your task description here!";
        }

        public void MakeProgress(Action onFinishedCallback = null)
        {
            //TODO implement the whole logic for doing progress
            // it'll differ from `one-shot` tasks to `recurring`
            
            onFinishedCallback?.Invoke();
        }
    }
}
