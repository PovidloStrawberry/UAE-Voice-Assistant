using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prev_Button : MonoBehaviour
{
    [SerializeField] Text_Panel text_panel;
    [SerializeField] GameObject text_object;
    public void On_Click()
    {
        text_panel.current_page--;
        text_object.GetComponent<TMPro.TextMeshProUGUI>().text = text_panel.pages_text[text_panel.current_page];
        text_panel.Update_Buttons();
    }
}
