using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerLevel : MonoBehaviour
{
	public GameObject menu;
	private string level0 = "FreeWorld";

    void OnTriggerEnter (Collider col)
    {

		if (SceneManager.GetActiveScene().name == level0) 
		{
			Time.timeScale = 0;
			menu.gameObject.SetActive(true);
		}

		if (col.gameObject.tag == "Player" && transform.name == "flag_med")
			//Debug.Log("flag");
			SceneManager.LoadScene(level0);

    }
}
