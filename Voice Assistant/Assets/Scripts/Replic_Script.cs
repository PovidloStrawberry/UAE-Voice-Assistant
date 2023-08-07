using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Replic_Script : MonoBehaviour
{
    public GameObject next_replic;
    public bool has_next_replic;
    public bool is_avatar_replic;
    public string text_from_voice;
    [SerializeField] private Text_Panel text_panel;
    [SerializeField] private GameObject[] replic_answers;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject avatar;

    [SerializeField] private GameObject[] questions;
    void Start()
    {
        animator = GetComponent<Animator>();
        avatar = GameObject.Find("Arab_Mesh_Animated");
        Replics.active_replics.Add(gameObject);
        text_panel = GetComponent<Text_Panel>();
    }
    private void Opent_Dialoge_Replics()
    {
        if (is_avatar_replic)
        {
            foreach (GameObject replic in  replic_answers)
            {
                replic.SetActive(true);
            }
        }
    }
    private void Update()
    {
        if (is_avatar_replic && text_panel.Is_Text_Typed)
        {
            Opent_Dialoge_Replics();
        }
    }
    public void Next_Replic()
    {
        
        text_panel.Type_Full_Text();
        if (has_next_replic)
        {if (!is_avatar_replic)
        {
            avatar.GetComponent<Animator>().Play("Arab_Agreed");
        }
            foreach (GameObject replic in Replics.active_replics)
            {
                if (gameObject != replic)
                {
                    replic.GetComponent<Animator>().Play("Close_Replic");
                    replic.SetActive(false);
                }
            }
            next_replic.SetActive(true);
            Replics.active_replics.Add(next_replic);
            animator.Play("Close_Replic");
            gameObject.SetActive(false);
        }
        
    }
    public void Voice()
    {
        if (has_next_replic)
        {
            if (!is_avatar_replic)
            {
                avatar.GetComponent<Animator>().Play("Arab_Agreed");
            }
            foreach (GameObject replic in Replics.active_replics)
            {
                if (gameObject != replic)
                {
                    replic.GetComponent<Animator>().Play("Close_Replic");
                    replic.SetActive(false);
                }
            }
            next_replic.SetActive(true);
            Replics.active_replics.Add(next_replic);
            animator.Play("Close_Replic");
            gameObject.SetActive(false);
        }
    }
    public void To_Questions()
    {
        if (!text_panel.Is_Text_Typed)
        {
            text_panel.Type_Full_Text();
        }
        else {
            foreach (GameObject question in questions)
            {
                question.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
