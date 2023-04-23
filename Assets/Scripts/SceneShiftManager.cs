using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneShiftManager : MonoBehaviour
{
    public static SceneShiftManager Instance;

    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
    public void OpenGameStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenLobbyScene()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenGameScene()
    {
        SceneManager.LoadScene(2);
    }
    public void OpenGameEndScene()
    {
        SceneManager.LoadScene(3);
    }
}
