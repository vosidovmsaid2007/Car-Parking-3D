using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class carSelection : MonoBehaviour
{
    public Image lockedImage;
    public Transform[] cars = new Transform[3];

    int activeCarIndex = 0;

    private Dictionary<int, int> carUnlockLevels = new Dictionary<int, int>
    {
        { 0, 1 }, { 1, 5 }, { 2, 20 }
    };

    void Start()
    {
        activeCarIndex = PlayerPrefs.GetInt("CarIndex", 0);
        cars[activeCarIndex].gameObject.SetActive(true);

        Time.timeScale = 1f;
    }

    public void NextCar()
    {
        if (activeCarIndex < cars.Length-1)
        {
            cars[activeCarIndex].gameObject.SetActive(false);
            activeCarIndex++;
            cars[activeCarIndex].gameObject.SetActive(true);
        }
        UpdateCarSelection();
        SaveCarSelectedId();
    }

    public void PreviousCar()
    {
        if (activeCarIndex > 0)
        {
            cars[activeCarIndex].gameObject.SetActive(false);
            activeCarIndex--;
            cars[activeCarIndex].gameObject.SetActive(true);
        }
        UpdateCarSelection();
        SaveCarSelectedId();
    }

    private void UpdateCarSelection()
    {
        bool isUnlocked = IsCarUnlocked(activeCarIndex);

        if (!isUnlocked)
        {
            lockedImage.gameObject.SetActive(true);
        }
        else{
            lockedImage.gameObject.SetActive(false);
        }
    }

    void SaveCarSelectedId(){
        if(IsCarUnlocked(activeCarIndex)){
            PlayerPrefs.SetInt("CarIndex", activeCarIndex);
            PlayerPrefs.Save();

            Debug.Log(activeCarIndex);
        }
    }

    private bool IsCarUnlocked(int carIndex)
    {
        int currentLevel = PlayerPrefs.GetInt("Record_Level", 1); // Get the player's current level
        return currentLevel >= carUnlockLevels[carIndex];
    }
}
