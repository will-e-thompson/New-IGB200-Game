using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public GameObject controlsPanel;
    private bool showControlsPanel = false;
    public GameObject optionsPanel;
    private bool showOptionsPanel = false;
    public GameObject aboutPanel;
    private bool showAboutPanel = false;

    public void Start()
    {
        controlsPanel.gameObject.SetActive(false);
        optionsPanel.gameObject.SetActive(false);
        aboutPanel.gameObject.SetActive(false);
    }

    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void toggleControlPanel()
    {
        if (showControlsPanel)
        {
            showControlsPanel = false;
        }
        else
        {
            showControlsPanel = true;
        }

        controlsPanel.gameObject.SetActive(showControlsPanel);
       
    }

    public void toggleOptionPanel()
    {
        if (showOptionsPanel)
        {
            showOptionsPanel = false;
        }
        else
        {
            showOptionsPanel = true;
        }

        optionsPanel.gameObject.SetActive(showOptionsPanel);

    }

    public void toggleAboutPanel()
    {
        if (showAboutPanel)
        {
            showAboutPanel = false;
        }
        else
        {
            showAboutPanel = true;
        }

        aboutPanel.gameObject.SetActive(showAboutPanel);

    }
}
