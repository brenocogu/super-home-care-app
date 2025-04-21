using System;
using UnityEngine;
using UnityEngine.UI;
using SuperHomeCare.Tasks;
using SuperHomeCare.UI.Components;
using UnityEngine.Pool;
using System.Collections.Generic;
using System.Linq;

namespace SuperHomeCare.UI
{
    public class TodoListView : MonoBehaviour
    {
        public event Action<Guid> OnTaskCompletedClicked; 
        
        [SerializeField] TodoListTaskObject taskPrefab;
        [SerializeField] Transform content;
        [SerializeField] ScrollRect scroll;
        IObjectPool<TodoListTaskObject> taskPool;
        List<TodoListTaskObject> activeTasks;
        TodoListTaskObject previousExpanded;
        
        void Start()
        {
            activeTasks = new();
            taskPool = new ObjectPool<TodoListTaskObject>(CreateFunc, actionOnRelease: OnReleaseToPool);
        }

        void OnReleaseToPool(TodoListTaskObject obj)
        {
            obj.gameObject.SetActive(false);
            activeTasks.Remove(obj);
        }

        TodoListTaskObject CreateFunc()
        {
            TodoListTaskObject obj = Instantiate(taskPrefab, content);
            obj.OnCompleteClicked += OnCompletedClick;
            obj.OnExpandClicked += OnOnExpandClicked;
            return obj;
        }

        void OnCompletedClick(Guid completedGuid)
        {
            TodoListTaskObject toRelease = activeTasks.First(x => x.CurrentTaskGuid == completedGuid);
            if (toRelease == previousExpanded)
                previousExpanded = null;
            taskPool.Release(toRelease);
            OnTaskCompletedClicked?.Invoke(completedGuid);
        }

        void OnOnExpandClicked(Guid taskGuid)
        {
            if(previousExpanded)
            {
                previousExpanded.Shrink();
                if (previousExpanded.CurrentTaskGuid == taskGuid)
                {
                    previousExpanded = null;
                    return;
                }
            }

            TodoListTaskObject toExpand = activeTasks.First(x => x.CurrentTaskGuid == taskGuid);
            toExpand.Expand();
            previousExpanded = toExpand;
        }

        public void AddChildTask(TaskData task)
        {
            TodoListTaskObject taskObj = taskPool.Get();
            activeTasks.Add(taskObj);
            taskObj.InitializeTaskData(task);
            taskObj.gameObject.SetActive(true);
        }
    }
}
