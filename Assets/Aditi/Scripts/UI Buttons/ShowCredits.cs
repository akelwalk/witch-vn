using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour
{
    public GameObject buttons;
    public GameObject credits;

    public void showButtons()
    {
        buttons.SetActive(true);
        credits.SetActive(false);
    }

    public void showCredits()
    {
        buttons.SetActive(false);
        credits.SetActive(true);
    }
}
