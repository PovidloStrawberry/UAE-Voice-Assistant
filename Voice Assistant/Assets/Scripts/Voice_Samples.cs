using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Voice_Samples : MonoBehaviour
{
    public List<AudioClip> samples;
    public Dictionary<string, AudioClip> samples_dictionary;
    public Dictionary<string, Action> actions;
    private void Start()
    {
        samples_dictionary = new Dictionary<string, AudioClip>
        {
            { "Hi", samples[0] },
            { "Hi!", samples[0] },
            { "Hallo", samples[0] },
            { "How are you", samples[1] },
            { "How are you?", samples[1] },
            { "Tell me about youself", samples[2] },
            { "Tell about youself", samples[2] }
        };
    }
}
