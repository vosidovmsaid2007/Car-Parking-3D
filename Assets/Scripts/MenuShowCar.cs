using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShowCar : MonoBehaviour
{
    public Transform[] cars = new Transform[3];
    public GameObject garagePrefab;

    private int activeCarIndex = 0;
    public Vector3 spawnPosition = new Vector3(22f, 0.1f, -1f);

    void Awake()
    {

        Time.timeScale = 1f;
        
        LoadGameObjects();
    }
    
    void LoadGameObjects()
    {
        activeCarIndex = PlayerPrefs.GetInt("CarIndex", 0);
        if (activeCarIndex >= 0 && activeCarIndex < cars.Length)
        {
            Instantiate(cars[activeCarIndex], spawnPosition, Quaternion.identity);
            Instantiate(garagePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Debug.LogError("Invalid CarIndex or cars not assigned properly.");
        }
    }
}
