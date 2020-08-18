using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button optionsButton;
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
  
    public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            goalMat.color = Color.blue;
            trapMat.color = new Color32(255, 112, 0, 1);
        }
        else
        {
            goalMat.color = new Color32(0, 255, 0, 255);
            trapMat.color = new Color32(255, 0, 0, 255);
        }
        SceneManager.LoadScene(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(PlayMaze);
        quitButton.onClick.AddListener(QuitMaze);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
