using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{   
    public static ButtonManager Instance { set; get; }
 
    [SerializeField] private GameObject StartPanel;

    [SerializeField] private GameObject HelpScreen;

    [SerializeField] private GameObject Jub;

    private bool inGame;

    public void Start()
    {
        Instance = this;
        inGame = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Debug.Log("P pressed");
            HelpClick();
        }
    }

    private void Toggle()
    {
        StartPanel.SetActive(!StartPanel.activeSelf);
        HelpScreen.SetActive(!HelpScreen.activeSelf);
    }

    public void StartClick()
    {
        Ball.Instance.StartThis();
        Jub.SetActive(true);
        inGame = true;
        StartPanel.SetActive(false);
        Debug.Log("Start function run.");
    }
    public void QuitClick()
    {
        Debug.Log("Quit function run.");
    }

    public void HelpClick()
    {
        Debug.Log(inGame);
        // Debug.Log("The help menu was clicked.");
        if (!inGame)
        {
            Toggle();
        }
        // Toggle();
        /* if(inGame && HelpScreen.activeSelf)
        {
            Time.timeScale = 1;
        }*/
        else
        {
            if (HelpScreen.activeSelf)
            {
                HelpScreen.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                HelpScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

}