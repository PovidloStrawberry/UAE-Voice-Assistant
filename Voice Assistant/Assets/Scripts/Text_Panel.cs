using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Panel : MonoBehaviour
{
    public int current_page = 0;
    public List<string> pages_text;
    [SerializeField] protected Slow_Typing typer;
    [SerializeField] protected GameObject text_field;
    public GameObject next_button;
    public GameObject prev_button;
    private bool is_text_typed;
    public bool Is_Text_Typed
    {
        get
        {
            return is_text_typed;
        }
        protected set
        {
            is_text_typed = value;
            Update_Buttons();
        }
    }
    public void Update_Buttons()
    {
        if (is_text_typed)
        {
            if (current_page == 0)
                prev_button.SetActive(false);
            else
                prev_button.SetActive(true);

            if (current_page == pages_text.Count - 1)
                next_button.SetActive(false);
            else
                next_button.SetActive(true);
        }
        else
        {
            prev_button.SetActive(false);
            next_button.SetActive(false);
        }
    }
    public virtual void Type_Text()
    {
        typer.Type_Text(pages_text[current_page]);
    }
    public virtual void Type_Text(string text)
    {
        typer.Type_Text(text);
    }
    public virtual void Type_Full_Text()
    {
        typer.Type_Full_Text();
    }
    public virtual void On_Click()
    {
        if (Is_Text_Typed)
        {
            if (current_page + 1 == pages_text.Count)
            {
                On_Text_End();
            }
            else
            {
                current_page++;
                Type_Text();
            }
        }
        else
        {
            Type_Full_Text();
        }
        Update_Buttons();
    }
    public virtual void Typed()
    {
        Is_Text_Typed = true;
    }
    public virtual void Not_Typed()
    {
        Is_Text_Typed = false;
    }
    public virtual void On_Text_End()
    {

    }
}
