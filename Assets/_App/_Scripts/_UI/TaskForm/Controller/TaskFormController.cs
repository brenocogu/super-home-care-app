using UnityEngine;
using SuperHomeCare.Tasks;
using VContainer.Unity;

namespace SuperHomeCare.UI.Components
{
    public class TaskFormController: IStartable
    {
        readonly TaskFormView view;
        readonly TaskManagerController taskManager;
        
        public TaskFormController(
            TaskFormView view,
            TaskManagerController taskManager)
        {
            this.view = view;
            this.taskManager = taskManager;
        }

        public void Start()
        {
            view.OnCreateButtonClicked += HandleCreateNewTask;
            view.OnCloseButtonClicked += HandleClose;
        }

        public void Open() => view.Open();
        
        void HandleClose()
        {
            //TODO if a person has already filled a description, or typed a lot, show a confirmation popup regarding to confirm the closure
            if(view.DescriptionInput.Length >= 15)
                Debug.Log("<color=cyan> we should present a confirmation popup here");
            view.Close();
        }

        void HandleCreateNewTask()
        {
            taskManager.CreateTask(view.NameInput, view.DescriptionInput);
            view.ClearInputs();
            HandleClose();
        }
    }
}