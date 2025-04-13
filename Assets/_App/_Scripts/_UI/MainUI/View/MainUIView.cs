using System;
using UnityEngine;
using UnityEngine.UI;

namespace SuperHomeCare.UI.Main
{
    public class MainUIView: MonoBehaviour
    {
        public Action OnMyTaskCompleted;
        
        [field: SerializeField] Button CompleteMyTaskButton;

        void Awake()
        {
            CompleteMyTaskButton.onClick.AddListener(() => OnMyTaskCompleted.Invoke());
        }
    }
}
