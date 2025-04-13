using System;
using UnityEngine;

namespace SuperHomeCare.TechnicalDebt.TVFP
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(MeshRenderer))]
    public class PawnView : MonoBehaviour
    {
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }
    }
}
