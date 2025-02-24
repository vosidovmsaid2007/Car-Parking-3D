using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButtons : MonoBehaviour
{
    [SerializeField]
    private Canvas mainButtonsCanvas, exitCanvas;

    [SerializeField]
    private string garageSceneName, startSceneName;

    [SerializeField]
    private string moreGames, rateUs;

    void Start(){

    }

    public void ActiveExitCanvas(){
        mainButtonsCanvas.enabled = false;
        exitCanvas.enabled = true;
    }

    public void YesExit(){
        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void NoExit(){
        mainButtonsCanvas.enabled = true;
        exitCanvas.enabled = false;
    }

    public void OpenMoreGames(){
        Application.OpenURL(moreGames);
    }

    public void OpenRateUs(){
        Application.OpenURL(rateUs);
    }

    public void OpenGarage(){
        SceneManager.LoadScene(garageSceneName);
    }

    public void OpenSceneByName(string SceneName){
        SceneManager.LoadScene(SceneName);
    }

    public void StartGame(){
        SceneManager.LoadScene(startSceneName);
    }
}