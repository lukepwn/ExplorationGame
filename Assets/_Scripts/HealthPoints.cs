using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
	
	private float playerhp;
	
    // Start is called before the first frame update
    void Start()
    {
        playerhp = 100;
    }

	public void Heal() 
	{
		Debug.Log(playerhp);
		playerhp += 25;
		Debug.Log(playerhp);
	}
	
	public void TakeDamage()
	{
		playerhp -= 30;
		Debug.Log(playerhp);
	}
	
}
