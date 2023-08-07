using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using System.Globalization;
using System.Diagnostics;
using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Configuration;

public class Voice_Controller : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    private bool is_listening_started = false;
    [SerializeField] private Replic_Script hi_replic;
    [SerializeField] private Replic_Script start_replic;
    [SerializeField] private Replic_Script reschedule_replic;
    [SerializeField] private Replic_Script rent_replic;
    [SerializeField] private Replic_Script money_replic;
    [SerializeField] private Replic_Script you_can_replic;

    private string rent = "what are the regulations for property rentals in dubai";
    private string hi = "hi";
    private string start = "tell about yourself";
    private string reschedule = "can you reschedule the meeting to another day where I have more free time";
    private string money = "i have free money where can i spend it";
    private string you_can = "yes you can and what are the required documents to support my mortgage application";
    //[SerializeField]
    //TMPro.TextMeshProUGUI text;

    void Start()
    {
        Setup(LANG_CODE);
        SpeechToText.Instance.onResultCallback = OnFinalSpeechResult;
    }
    public void Microphone()
    {
        if (!is_listening_started)
        {
            StartListening();
            is_listening_started = true;
        }
        else
        {
            StopListening();
            is_listening_started = false;
        }
    }
    public void OnSpeakStart()
    {
        UnityEngine.Debug.Log("Talking started...");

    }
    public void OnSpeakStop()
    {
        UnityEngine.Debug.Log("Talking stopped.");
    }
    #region Speech to Text
    public void StartListening()
    {
        //UnityEngine.Debug.Log("Talking started...");
        SpeechToText.Instance.StartRecording();
    }
    public void StopListening()
    {
        //UnityEngine.Debug.Log("Talking stopped.");
        SpeechToText.Instance.StopRecording();
    }
    void OnFinalSpeechResult(string result)
    {
        switch (result){
            case "hi":
                hi_replic.Voice();
                break;
            case "tell about yourself":
                start_replic.Voice();
                break;
            case "what are the regulations for property rentals in dubai":
                rent_replic.Voice();
                break;
            case "yes you can and what are the required documents to support my mortgage application":
                you_can_replic.Voice();
                break;
            case "can you reschedule the meeting to another day where I have more free time":
                reschedule_replic.Voice();
                break;
            case "i have free money where can i spend it":
                money_replic.Voice();
                break;
        }
            //UnityEngine.Debug.Log(result);
            //text.text = result; 
    }
    #endregion
    void Setup(string code)
    {
        SpeechToText.Instance.Setting(code);
    }
}
