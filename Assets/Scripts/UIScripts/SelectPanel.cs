using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectPanel : MonoBehaviour
{


    public GameObject buttonLeft;
    public GameObject buttonRight;
    public GameObject buttonBack;
    public GameObject buttonStart;
    public TextMeshProUGUI stageText;

    public GameObject selectPanel;
    public GameObject chooseLVPanel;

    public Sprite stage1;
    public Sprite stage2;
    

    private string[] stageName = new string[2]{"체육관", "아이스링크"};



    public GameObject stageImage;
    private Image stageImageImageComponent;
   
    //public GameObject startPanel;

    private int currentStage;
    private int stageCount;
    private Sprite[] previewSprites;

   
    // Start is called before the first frame update
    void Awake()
    {

        if (stageImage != null)
        {
            //이미지가 없다면 이미지 컴포턴트에서 가져온다 
            stageImageImageComponent = stageImage.GetComponent<Image>();
            
        }

        stageCount = 2;
        previewSprites = new Sprite[stageCount];
        previewSprites[0] = stage1;
        previewSprites[1] = stage2;

        currentStage = 0;
        stageText.text = stageName[currentStage];
        SetButtonEvent();




    }

    private void SetButtonEvent()
    {

        buttonLeft.GetComponent<Button>().onClick.AddListener(ButtonLeftClicked);
        buttonRight.GetComponent<Button>().onClick.AddListener(ButtonRightClicked);
        buttonBack.GetComponent<Button>().onClick.AddListener(ButtonBackClicked);
        buttonStart.GetComponent<Button>().onClick.AddListener(MoveToGame);

    }

    public void MoveToGame()
    {
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
        if (stageText.text.Equals(stageName[0]))
        {
            StartCoroutine(LoadingStage1());
        }
        else {

            StartCoroutine(LoadingStage2());
        }

        GameManager.Instance.StartGame();
        Debug.Log("GameManager");
    }

    IEnumerator LoadingStage1()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync("Stage_1");
        
        while (!loading.isDone) //씬 로딩 완료시 로딩완료시 완료
        {
            
            yield return null;
        }
    }

    IEnumerator LoadingStage2()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync("Stage_2");

        while (!loading.isDone) //씬 로딩 완료시 로딩완료시 완료
        {

            yield return null;
        }
    }



    public void ButtonBackClicked()
    {
        chooseLVPanel.SetActive(true);
        selectPanel.SetActive(false);
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
    }

    public void ButtonLeftClicked()
    {
        currentStage += stageCount;
        currentStage--;
        currentStage %= stageCount;
        change_stage(currentStage);


    }

    public void ButtonRightClicked()
    {
        currentStage++;
        currentStage %= stageCount;
        change_stage(currentStage);

    }


    public void change_stage(int stage)
    {

        set_stage_image(stage);
        set_stage_text(stage);
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
    }

    private void set_stage_text(int stage)
    {
        
        //int stageNum = stage + 1;
        stageText.text = stageName[stage];
        Debug.Log(stageText.text);

    }

    private void set_stage_image(int stage)
    {
        int index = stage;
        if (index < 0 || stageCount <= index || stageImageImageComponent == null) return;
        stageImageImageComponent.sprite = previewSprites[index];
    }

    public void buttonExit_clicked()
    {
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }


 

}
