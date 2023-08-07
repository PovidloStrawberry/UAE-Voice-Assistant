using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic_Text : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private Slow_Typing typer;
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

    private void OnEnable()
    {
        typer.Type_Text(text);
    }
    private void OnDisable()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }
}
