using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    private string CurrentScene;
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        CurrentScene = SceneManager.GetActiveScene().name;
        switch (CurrentScene)
        {
            case "Level01":
                SceneManager.LoadScene("Level02");
                break;
            case "Level02":
                SceneManager.LoadScene("Level03");
                break;
            case "Level03":
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }
}
