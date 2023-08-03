using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.iOS;

public class Voice_Recognition : MonoBehaviour
{
    private KeywordRecognizer word_recognizer;
    [SerializeField] private Arab_Avatar avatar;
    private string[] words = { "Hi", "Hallo", "How are you", "Tell me about youself", "Tell about youself" };
    void Start()
    {
        word_recognizer = new KeywordRecognizer(words);
        word_recognizer.OnPhraseRecognized += Recognized_Speech;
    }
    public void Start_Recognition()
    {
        word_recognizer.Start();
    }
    public void Stop_Recognition()
    {
        word_recognizer.Stop();
    }
    private void Recognized_Speech(PhraseRecognizedEventArgs speech)
    {
        avatar.Send_Text(speech.text);
        Stop_Recognition();
    }
}
