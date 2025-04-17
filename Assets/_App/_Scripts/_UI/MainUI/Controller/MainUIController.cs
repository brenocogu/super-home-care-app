using System;
using UnityEngine;
using VContainer.Unity;
using SuperHomeCare.Tasks;
using SuperHomeCare.UI.Components;

namespace SuperHomeCare.UI.Main
{
    public class MainUIController: IStartable, IDisposable
    {
        readonly MainUIView view;
        readonly TaskManagerController taskManager;
        readonly CreateTaskOpenButtonView createTaskButtonView;
        readonly TaskFormController taskFormController;
        MenuState createTaskButtonState = MenuState.Closed;
        
        public MainUIController(
            MainUIView view,
            TaskManagerController taskManager,
            CreateTaskOpenButtonView createTaskButtonView,
            TaskFormController taskFormController)
        {
            this.view = view;
            this.taskManager = taskManager;
            this.createTaskButtonView = createTaskButtonView;
            this.taskFormController = taskFormController;
        }
        
        public void Start()
        {
            view.OnMyTaskCompleted += HandleTaskCompleted;
            createTaskButtonView.OnTaskButtonClicked += HandleCreateTask;
            createTaskButtonView.OnCreateTaskMenuButtonClicked += HandleOpenMenu;
            taskFormController.Start();
        }

        void HandleOpenMenu()
        {
            switch (createTaskButtonState)
            {
                case MenuState.Closed:
                    createTaskButtonView.PlayOpenAnimation();
                    break;
                case MenuState.Open:
                    createTaskButtonView.PlayCloseAnimation();
                    break;
            }

            createTaskButtonState = (MenuState)(-(int)createTaskButtonState);
        }
        
        void HandleCreateTask(int _) //it is _ now, but we should open a preset depending on the task button clicked
        {
            taskFormController.Open();
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
