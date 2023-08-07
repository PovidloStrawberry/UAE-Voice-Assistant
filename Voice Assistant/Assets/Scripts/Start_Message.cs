using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Message : Text_Panel
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject arab_avatar;
    [SerializeField] GameObject hi_user_replic;
    [SerializeField] GameObject micro_button;
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
        yield return new WaitForSeconds(1f);
        arab_avatar.SetActive(true);
        micro_button.SetActive(true);
        hi_user_replic.SetActive(true);
        gameObject.SetActive(false);
    }
    public override void On_Text_End()
    {
        StartCoroutine(Wait_For_Close());
        animator.Play("Close_Start_Window");
    }
}
