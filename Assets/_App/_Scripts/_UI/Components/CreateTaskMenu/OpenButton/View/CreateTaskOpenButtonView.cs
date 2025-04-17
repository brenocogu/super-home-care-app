using System;
using UnityEngine;
using UnityEngine.UI;

namespace SuperHomeCare.UI.Components
{
    public class CreateTaskOpenButtonView : MonoBehaviour
    {
        public Action OnCreateTaskMenuButtonClicked;
        public Action<int> OnTaskButtonClicked;
        
        
        [SerializeField] Animation anim;
        [SerializeField] AnimationClip openAnim, closeAnim;
        [SerializeField] Button button;
        [SerializeField] Button simpleTaskButton, recurringTaskButton;

        void Awake()
        {
            button.onClick.AddListener(() => OnCreateTaskMenuButtonClicked?.Invoke());
            simpleTaskButton.onClick.AddListener(() => OnTaskButtonClicked?.Invoke(0));
            recurringTaskButton.onClick.AddListener(() => OnTaskButtonClicked?.Invoke(1));
        }

        public void PlayOpenAnimation()
        {
            anim.clip = openAnim;
            anim.Play();
        }

        public void PlayCloseAnimation()
        {
            anim.clip = closeAnim;
            anim.Play();
        }
    }
}
