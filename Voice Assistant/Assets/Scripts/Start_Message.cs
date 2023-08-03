using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Message : Text_Panel
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject arab_avatar;
    void Start()
    {
        Update_Buttons();
        animator.Play("Open_Start_Window");
        StartCoroutine(Wait_For_Open());
    }
    private IEnumerator Wait_For_Open()
    {
        yield return new WaitForSeconds(0.5f);
        Type_Text();
    }
    private IEnumerator Wait_For_Close()
    {
        yield return new WaitForSeconds(0.5f);
        arab_avatar.SetActive(true);
        Destroy(gameObject);
    }
    public override void On_Text_End()
    {
        StartCoroutine(Wait_For_Close());
        animator.Play("Close_Start_Window");
    }
}
