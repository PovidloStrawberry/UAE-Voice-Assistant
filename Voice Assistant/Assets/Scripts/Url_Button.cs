using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Url_Button : MonoBehaviour
{
    [SerializeField] private string url;
    public void Open_Url()
    {
        Application.OpenURL(url);
    }
}
