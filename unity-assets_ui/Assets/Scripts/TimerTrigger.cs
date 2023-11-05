using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
	public GameObject player;
	public GameObject pauseCanvas;

	void OnTriggerExit(Collider other)
	{
		if (!pauseCanvas.activeSelf)
		{
            if (!other.CompareTag("Timetrigger"))
            {
                player.GetComponent<Timer>().enabled = true;
            }
        }
	}
}
