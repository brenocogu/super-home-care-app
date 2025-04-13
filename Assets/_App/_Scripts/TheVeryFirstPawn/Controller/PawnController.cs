using System;
using UnityEngine;
using SuperHomeCare.Tasks;
using VContainer.Unity;

namespace SuperHomeCare.TechnicalDebt.TVFP
{
    public class PawnController: IPostStartable
    {
        readonly TaskManagerController taskManager;
        readonly PawnView view;

        public PawnController(
            PawnView view, 
            TaskManagerController taskManager
            )
        {
            this.view = view;
            this.taskManager = taskManager;
        }

        public void PostStart()
        {
            taskManager.OnTaskCompleted += HandleTaskCompleted;
        }

        void HandleTaskCompleted(Guid obj)
        {
            Debug.Log("Will change the view now");
        }
    }
}
