using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public GameObject buttonPrefab; // The level button prefab
    public Transform content; // The content of the scroll view
    public int totalLevels = 80; // Total number of levels
    public Color completedColor = Color.green;

    public bool RestoreGame;

    void Start()
    {

        int currentLevel = PlayerPrefs.GetInt("Record_Level", 1);
        
        for (int i = 1; i <= totalLevels; i++)
        {
            GameObject button = Instantiate(buttonPrefab, content);
            button.GetComponentInChildren<Text>().text = ""+i;

            Button btn = button.GetComponent<Button>();

            if (i <= currentLevel)
            {
                button.GetComponent<Image>().color = completedColor;
            }
            else
            {
                btn.interactable = false;
            }

            int levelIndex = i;
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    void LoadLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("SceneLevel", levelIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
