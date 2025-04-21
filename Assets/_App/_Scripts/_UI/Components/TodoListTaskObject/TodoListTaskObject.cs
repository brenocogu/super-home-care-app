using System;
using System.Collections;
using SuperHomeCare.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SuperHomeCare.UI.Components
{
    public class TodoListTaskObject : MonoBehaviour
    {
        public event Action<Guid> OnExpandClicked;
        public event Action<Guid> OnCompleteClicked;
        
        public Guid CurrentTaskGuid => taskGuid;
        
        [SerializeField] TextMeshProUGUI taskName;
        [SerializeField] TextMeshProUGUI taskDescription;
        [SerializeField] RectTransform rectTansform;
        [SerializeField] Button expandButton, completeButton;
        //TODO Add also a REMOVE button and EDIT button
        Guid taskGuid;
        
        void Awake()
        {
            expandButton.onClick.AddListener(() => OnExpandClicked?.Invoke(taskGuid));
            completeButton.onClick.AddListener(() => OnCompleteClicked?.Invoke(taskGuid));
        }

        public void Expand()
        {
            StopAllCoroutines();
            StartCoroutine(HeightRoutine(210));
            expandButton.transform.localEulerAngles = Vector3.back * 90;
        }

        public void Shrink()
        {
            StopAllCoroutines();
            StartCoroutine(HeightRoutine(80));
            expandButton.transform.localEulerAngles = Vector3.zero;
        }

        IEnumerator HeightRoutine(float finalValue)
        {
            float initialHeight = rectTansform.sizeDelta.y;
            float t = 0;
            while (Mathf.Abs(rectTansform.sizeDelta.y - finalValue) > Mathf.Epsilon)
            {
                yield return new WaitForEndOfFrame();
                float y = Mathf.Lerp(initialHeight, finalValue, t);
                t += Time.deltaTime * 2;
                rectTansform.sizeDelta = new Vector2(rectTansform.sizeDelta.x, y);
            }
        }

        public void InitializeTaskData(TaskData atask)
        {
            taskName.text = atask.TaskName;
            expandButton.gameObject.SetActive(!string.IsNullOrEmpty(atask.TaskDescription));
            taskDescription.text = atask.TaskDescription;
            taskGuid = atask.TaskGUID;
        }
    }
}