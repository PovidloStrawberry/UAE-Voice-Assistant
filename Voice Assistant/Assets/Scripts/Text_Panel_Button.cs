using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Panel_Button : MonoBehaviour
{
    [SerializeField] Text_Panel text_panel;
    public void On_Click()
    {
        text_panel.On_Click();
    }
    public void Start()
    {
        
    }
}
