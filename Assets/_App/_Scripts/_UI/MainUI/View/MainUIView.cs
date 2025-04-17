using System;
using UnityEngine;
using UnityEngine.UI;

namespace SuperHomeCare.UI.Main
{
    public class MainUIView: MonoBehaviour
    {
        public event Action OnMyTaskCompleted;
        
        [field: SerializeField] Button completeMyTaskButton;

        void Awake()
        {
            completeMyTaskButton.onClick.AddListener(() => OnMyTaskCompleted?.Invoke());
        }
    }
}
