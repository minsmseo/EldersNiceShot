using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HammerUIPanel : MonoBehaviour
{
    public Button settingButton;
    public Button manualButton;
    public Button backButton;
    public Button exitButton;

    public GameObject hammerUIPanel;


    private void Awake()
    {
        settingButton.onClick.AddListener(buttonSetting_clicked);
        manualButton.onClick.AddListener(buttonManual_clicked);
        backButton.onClick.AddListener(buttonBack_clicked);
        exitButton.onClick.AddListener(buttonExit_clicked);


    }

    public void buttonSetting_clicked()
    {
        hammerUIPanel.SetActive(false);

    }

    public void buttonManual_clicked()
    {
        hammerUIPanel.SetActive(false);

    }

    public void buttonBack_clicked()
    {
       SceneManager.LoadScene("Main_Lobby");
    }

    public void buttonExit_clicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }


}
