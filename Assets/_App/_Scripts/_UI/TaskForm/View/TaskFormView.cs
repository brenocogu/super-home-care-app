using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace SuperHomeCare.UI.Components
{
    public class TaskFormView : MonoBehaviour
    {
        public event Action OnCreateButtonClicked; 
        public event Action OnCloseButtonClicked;

        public string NameInput => taskName.text;
        public string DescriptionInput => taskDescription.text;

        [SerializeField] Animation animation;
        [SerializeField] Button createButton, closeButton;
        [SerializeField] TMP_InputField taskName, taskDescription;
        [SerializeField] AnimationClip openClip, closeClip;
        
        void Awake()
        {
            createButton.onClick.AddListener(() => OnCreateButtonClicked?.Invoke());
            closeButton.onClick.AddListener(() => OnCloseButtonClicked?.Invoke());
        }

        public void Open()
        {
            transform.localScale = Vector3.one;
            gameObject.SetActive(true);
            animation.clip = openClip;
            animation.Play();
        }
        
        public async void Close()
        {
            gameObject.SetActive(true);
            animation.clip = closeClip;
            animation.Play();
            await Task.Delay(Mathf.CeilToInt(animation.clip.length) * 1000);
            transform.localScale = Vector3.zero;
        }

        public void ClearInputs()
        {
            taskName.text = "";
            taskDescription.text = "";
        }
    }
}
