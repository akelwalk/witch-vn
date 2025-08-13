using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject buttons;
    public GameObject credits;
    public GameObject controls;

    public void showButtons()
    {
        buttons.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
    }

    public void showCredits()
    {
        buttons.SetActive(false);
        credits.SetActive(true);
    }

    public void showControls()
    {
        buttons.SetActive(false);
        controls.SetActive(true);
    }
}
