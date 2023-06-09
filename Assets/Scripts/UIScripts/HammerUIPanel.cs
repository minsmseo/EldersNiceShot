using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class HammerUIPanel : MonoBehaviour
{
    //public Button settingButton;
    public Button manualButton;
    public Button backButton;
    public Button exitButton;
    public Button closeButton;

    public GameObject hammerUIPanel;
    public GameObject manualPanel;



    public void Awake()
    {
        manualPanel.SetActive(false);
        hammerUIPanel.SetActive(false);
        SetAddListener();   
    }

    public void SetAddListener()
    {      
        //settingButton.onClick.AddListener(buttonSetting_clicked);
        manualButton.onClick.AddListener(buttonManual_clicked);
        backButton.onClick.AddListener(buttonBack_clicked);
        exitButton.onClick.AddListener(buttonExit_clicked);
        closeButton.onClick.AddListener(buttonClose_clicked);

    }
    //public void buttonSetting_clicked()
    //{
    //    hammerUIPanel.SetActive(false);
    //    ColorBlock col = settingButton.colors;
    //    col.normalColor = new Color(255, 20, 147);
    //    settingButton.colors = col;
    //}

    public void buttonManual_clicked()
    {
        hammerUIPanel.SetActive(false);
        manualPanel.SetActive(true);

    }

    public void buttonBack_clicked()
    {
       SceneManager.LoadScene("Main_Lobby");
    }

    public void OpenUIPanel(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            hammerUIPanel.SetActive(true);
        }
    }

    public void buttonExit_clicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }

    public void buttonClose_clicked()
    {
        hammerUIPanel.SetActive(false);

    }


}
