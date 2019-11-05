using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel : MonoBehaviour
{

    private string level1 = "Level1";
	private string level0 = "FreeWorld";


    void OnTriggerEnter (Collider col)
    {
		//Debug.Log(transform.name);
		
		if (transform.name == "flag")
			SceneManager.LoadScene(level0);
		
		
		if (transform.name == "Fortress Gate") 
			SceneManager.LoadScene(level1);
		
    }
}
