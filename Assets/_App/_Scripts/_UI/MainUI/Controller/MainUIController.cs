using System;
using UnityEngine;
using VContainer.Unity;
using SuperHomeCare.Tasks;

namespace SuperHomeCare.UI.Main
{
    public class MainUIController: IStartable, IDisposable
    {
        readonly MainUIView view;
        readonly TaskManagerController taskManager;

        public MainUIController(
            MainUIView view,
            TaskManagerController taskManager)
        {
            this.view = view;
            this.taskManager = taskManager;
        }
        
        public void Start()
        {
            view.OnMyTaskCompleted += HandleTaskCompleted;
        }

        void HandleTaskCompleted()
        {
            //Todo make any feedback
            //like a 🎊 or smth like that i dunno
            taskManager.ProgressTask(Guid.Empty);
        }

        public void Dispose()
        {
            view.OnMyTaskCompleted -= HandleTaskCompleted;
        }
    }
}
