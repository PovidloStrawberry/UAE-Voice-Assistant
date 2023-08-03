using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Arab_Avatar : Text_Panel
{
    [SerializeField] private Voice_Samples voice_samples;
    [SerializeField] private AudioSource audio_source;
    [SerializeField] private List<AudioClip> used_clips;
    [SerializeField] private GameObject avatar_text_field;
    [SerializeField] private Text_Panel avatar_text_field_panel;
    [SerializeField] private Animator avatar_text_field_animator;
    [SerializeField] private GameObject input_panel;
    [SerializeField] private TMPro.TextMeshProUGUI input_panel_text;
    [SerializeField] private GameObject microphone_button;
    [SerializeField] private GameObject text_panel_button;
    [SerializeField] private GameObject questions_panel;
    public void Send_Text(string text)
    {
        input_panel.GetComponent<Animator>().Play("Input_Panel_Close");
        AudioClip audio_to_play = voice_samples.samples_dictionary[text];
        if (!used_clips.Contains(audio_to_play))
        {
            if (text == "Hi" || text == "Hi!")
            {
                Type_Text("Hi!");
                StartCoroutine(Input_Panel_Start(1, "How are you?"));
            }
            else if (text == "How are you" || text == "How are you?")
            {
                Type_Text("I am fine. How are you?");
                StartCoroutine(Input_Panel_Start(1, "Tell about youself"));
            }
            else if (text == "Tell me about youself" || text == "Tell about youself")
            {
                Type_Text("I am a voice assistant, I can advise on the acquisition of real estate, finance, and so on:");
                microphone_button.SetActive(false);
                StartCoroutine(Open_Question_Panel());
            }
            used_clips.Add(audio_to_play);
            audio_source.clip = audio_to_play;
            audio_source.Play();
        }
    }
    public void Send_Question(Question_Panel question)
    {
        Type_Text(question.answer_text);
        audio_source.clip = question.answer_audio;
        audio_source.Play();
    }
    void Start()
    {
        text_panel_button.SetActive(false);
        used_clips = new List<AudioClip>();
        StartCoroutine(Input_Panel_Start());
    }
    private IEnumerator Open_Question_Panel()
    {
        yield return new WaitForSeconds(6);
        questions_panel.SetActive(true);
    }
    private IEnumerator Input_Panel_Start()
    {
        yield return new WaitForSeconds(1);
        input_panel.GetComponent<Animator>().Play("Input_Panel_Start");
    }
    private IEnumerator Input_Panel_Start(float seconds, string text)
    {
        yield return new WaitForSeconds(seconds);
        input_panel.GetComponent<Animator>().Play("Input_Panel_Start");
        input_panel_text.text = text;
    }
    void Update()
    {
        
    }
}
