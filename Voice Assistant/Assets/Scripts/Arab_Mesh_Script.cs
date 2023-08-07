using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arab_Mesh_Script : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Start()
    {
        animator.Play("Arab_StartWalking");
    }
}
