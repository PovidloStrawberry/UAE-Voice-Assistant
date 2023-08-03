using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Field_Button : MonoBehaviour
{
    [SerializeField] private Arab_Avatar avatar;
    [SerializeField] TMPro.TextMeshProUGUI text;
    public void On_Click()
    {
        transform.parent.gameObject.GetComponent<Animator>().Play("Input_Panel_Close");
        avatar.Send_Text(text.text);
    }
}
