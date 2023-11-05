using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text Timer_Text;
    public GameObject Player;
    private float tempsActuel = 0f;
    public TextMeshProUGUI FinalTime;

    void Update()
    {
        Win();
        tempsActuel += Time.deltaTime;
        Timer_Text.text = FormatTemps(tempsActuel);  
    }

    string FormatTemps(float temps)
    {
        int minutes = Mathf.FloorToInt(temps / 60);
        int secondes = Mathf.FloorToInt(temps % 60);
        float centisecondes = (temps * 100) % 100;

        return string.Format("{0:00}:{1:00}:{2:00}", minutes, secondes, centisecondes);
    }

    public void Win()
    {
        FinalTime.text = Timer_Text.text;
    }


}
