using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
    public Button lv1;
    public Button lv2;
    public Button lv3;

	void Start()
	{
		lv1.onClick.AddListener(Level1);
		
		lv2.onClick.AddListener(Level2);
		
		lv3.onClick.AddListener(Level3);
	}

	void Level1 () 
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Level1");
	}
	
	void Level2 () 
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Level2");
	}
	
	void Level3 () 
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Level3");
	}
	
}
