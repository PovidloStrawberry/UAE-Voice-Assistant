using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using System.Globalization;
using System.Diagnostics;
using System.ComponentModel.Design;

public class Voice_Controller : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    private bool is_listening_started = false;
    [SerializeField]
    Text uiText;
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
        UnityEngine.Debug.Log("Talking started...");
        SpeechToText.Instance.StartRecording();
    }
    public void StopListening()
    {
        UnityEngine.Debug.Log("Talking stopped.");
        SpeechToText.Instance.StopRecording();
    }
    void OnFinalSpeechResult(string result)
    {
        UnityEngine.Debug.Log(result);
    }
    #endregion
    void Setup(string code)
    {
        SpeechToText.Instance.Setting(code);
    }
}
