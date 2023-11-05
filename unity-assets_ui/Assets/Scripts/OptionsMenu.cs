using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle InvertY;

    public void Start()
    {
        if (PlayerPrefs.GetInt("isInverted") == 1)
            InvertY.isOn = true;
        else
            InvertY.isOn = false;
    }
    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
    }

    public void Apply()
    {
        if (InvertY.isOn)
            PlayerPrefs.SetInt("isInverted", 1);
        else
            PlayerPrefs.SetInt("isInverted", 0);
        Time.timeScale = 1f;
        Back();
    }
}
