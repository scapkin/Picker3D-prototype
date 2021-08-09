using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class UiManager : Singleton<UiManager>
{
   [SerializeField]private bool levelFinish;
	
    public TextMeshProUGUI lvlText;
    public TextMeshProUGUI lvlFinishText;



    public GameObject winPanel;
    public GameObject losePanel;
	
    public GameObject successPanel;
    public GameObject failPanel;

    public Button startButton;

    private int level;

    private void Awake(){
        lvlText = GameObject.Find("LvlText").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        
        levelFinish = false;
		winPanel = GameObject.Find("Win");
        losePanel = GameObject.Find("Lose");
        level = PlayerPrefs.GetInt("Level",0);

        lvlText.text = "LEVEL" + " " + (level+1);

        winPanel.SetActive(false);
        losePanel.SetActive(false);
        	
        startButton = GameObject.Find("Button Play").GetComponent<Button>();
        startButton.onClick.AddListener(StartButton);
    }


    public void StartButton(){
        startButton.gameObject.SetActive(false);        
        MapGenerator.Instance.MapGenerate();
    }

    public void LevelFinishController()
    {
        LwlFinishDelay();

    }

    public void LevelFailUi()
    {
        failPanel.SetActive(true);

    }
    public void LwlFinishDelay(){
        winPanel.SetActive(true);
        successPanel.SetActive(true);
    }

    

    public void NewScene(){
        if (!levelFinish)
        {
            level++;
            PlayerPrefs.SetInt("Level",level);
            SceneManager.LoadScene(level%10);
            levelFinish = true;
        }
    }

    public void FailScene()
    {
        if (!levelFinish)
        {
            Debug.Log(level);
            SceneManager.LoadScene(level);
            levelFinish = true;
        }
    }
}
