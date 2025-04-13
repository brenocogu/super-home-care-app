using System;
using UnityEngine;

namespace SuperHomeCare.TechnicalDebt.TVFP
{
    public class PawnView : MonoBehaviour
    {
        [field: SerializeField] public Animation Animation { get; private set; }
        Animator anim;

        public void Play()
        {
            Animation.Play();
        }
    }
}
