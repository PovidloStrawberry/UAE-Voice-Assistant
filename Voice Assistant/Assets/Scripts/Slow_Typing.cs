using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;

public class Slow_Typing : MonoBehaviour
{
    public string text;
    [SerializeField] private Text_Panel text_panel;
    private int pointer = 0;
    public GameObject text_object;
    private float typing_speed;
    private const float base_typing_speed = 0.05f;
    private IEnumerator Text_Typer()
    {
        yield return new WaitForSeconds(typing_speed);
        text_object.GetComponent<TMPro.TextMeshProUGUI>().text += text[pointer];
        pointer++;
        if (pointer < text.Length)
            StartCoroutine(Text_Typer());
        else
            text_panel.Typed();
    }
    public void Type_Text(string text)
    {
        text_panel.Not_Typed();
        text_object.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        this.text = text;
        pointer = 0;
        typing_speed = base_typing_speed;
        StartCoroutine(Text_Typer());
    }
    public void Type_Full_Text()
    {
        typing_speed = 0.001f;
    }
    private void Start()
    {
        typing_speed = base_typing_speed;
    }
}
