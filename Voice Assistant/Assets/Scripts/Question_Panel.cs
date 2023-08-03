using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question_Panel : MonoBehaviour
{
    [SerializeField] Arab_Avatar avatar;
    [SerializeField] private string question_text;
    [SerializeField] public string answer_text;
    [SerializeField] public AudioClip answer_audio;
    [SerializeField] private TMPro.TextMeshProUGUI text_field;
    private void Start()
    {
        text_field.text = question_text;
    }
    public void On_Click()
    {
        if (avatar.Is_Text_Typed)
            avatar.Send_Question(this);
    }
}
