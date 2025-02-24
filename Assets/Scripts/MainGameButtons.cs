using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameButtons : MonoBehaviour
{

    public enum controllerType
    {
        ArrowTouch,
        Wheel
    }

    [SerializeField] private Button WheelButton, ArrowButton;

    [SerializeField] private Button settingButton, pauseButton, closeButton;

    [SerializeField] private Canvas MainCanvas;

    // Settings Menu
    [SerializeField] private GameObject SettingsMenu;

    [SerializeField] private Image WheelImg, RightArrowImg, LeftArrowImg;

    // Pause Menu
    [Header("Pause Menu")]
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private Button resume, restart, home;

    [Header("Game Over Menu")]
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private Button NextLevel_GameOver, Restart_GameOver, Home_GameOver;

    void Start()
    {
        MainCanvas.enabled = true;
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(false);

        WheelButton.GetComponent<Image>().color = Color.yellow;
        ArrowButton.GetComponent<Image>().color = Color.white;

        settingButton.onClick.AddListener(() => ClickSettingButton());
        pauseButton.onClick.AddListener(() => ClickPauseButton());
        closeButton.onClick.AddListener(() => ClickCloseButton());

        WheelButton.onClick.AddListener(() => ClickWheelButton());
        ArrowButton.onClick.AddListener(() => ClickArrowButton());

        resume.onClick.AddListener(() => ClickResumeButton());
        restart.onClick.AddListener(() => ClickRestartButton());
        home.onClick.AddListener(() => ClickHomeButton());

        NextLevel_GameOver.onClick.AddListener(() => ClickNextLevelButton());
        Restart_GameOver.onClick.AddListener(() => ClickRestartButton());
        Home_GameOver.onClick.AddListener(() => ClickHomeButton());
        
    }

    void ClickSettingButton()
    {
        MainCanvas.enabled = false;
        SettingsMenu.SetActive(true);

        settingButton.enabled = false;
        pauseButton.enabled = false;
    }

    void ClickPauseButton()
    {
        MainCanvas.enabled = false;
        PauseMenu.SetActive(true);

        settingButton.enabled = false;
        pauseButton.enabled = false;

        
    }

    void FinishGameButton(){
        MainCanvas.enabled = false;
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(true);

        settingButton.enabled = false;
        pauseButton.enabled = false;

        
    }

    void ClickCloseButton()
    {
        MainCanvas.enabled = true;
        SettingsMenu.SetActive(false);

        settingButton.enabled = true;
        pauseButton.enabled = true;
    }

    void ClickWheelButton()
    {
        WheelButton.GetComponent<Image>().color = Color.yellow;
        ArrowButton.GetComponent<Image>().color = Color.white;

        WheelImg.enabled = true;
        RightArrowImg.enabled = false;
        LeftArrowImg.enabled = false;

        gameObject.GetComponent<GameManager>().SetControllerType("Wheel");
    }

    void ClickArrowButton()
    {
        WheelButton.GetComponent<Image>().color = Color.white;
        ArrowButton.GetComponent<Image>().color = Color.yellow;

        WheelImg.enabled = false;
        RightArrowImg.enabled = true;
        LeftArrowImg.enabled = true;

        gameObject.GetComponent<GameManager>().SetControllerType("ArrowTouch");
    }

    void ClickResumeButton()
    {
        MainCanvas.enabled = true;
        PauseMenu.SetActive(false);

        settingButton.enabled = true;
        pauseButton.enabled = true;
    }

    void ClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void ClickHomeButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    void ClickNextLevelButton()
    {
        Debug.Log("Watch Ad!");
    }

    
}
