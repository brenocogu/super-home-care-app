using System;
using SuperHomeCare.Tasks;
using VContainer.Unity;

namespace SuperHomeCare.UI
{
    public class TodoListController : IStartable
    {
        readonly TodoListView view;
        readonly TaskManagerController taskManager;

        public TodoListController(
            TodoListView view,
            TaskManagerController taskManager)
        {
            this.view = view;
            this.taskManager = taskManager;
        }

        public void Start()
        {
            view.OnTaskCompletedClicked += OnTaskCompletedClick;
            taskManager.OnTaskCreated += OnTaskCreated;
            //TODO a loading can be put here so as the controller initializes the UI will present the proper content
        }

        void OnTaskCreated(TaskData task)
        {
            view.AddChildTask(task);
        }

        void OnTaskCompletedClick(Guid taskGuid) => taskManager.ProgressTask(taskGuid);
    }
}