using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
	
	public GameObject spawnpoint;

	public void Revive() 
	{
		GetComponent<CharacterController>().enabled = false;
		GetComponent<Animator>().enabled = false;
		
		Invoke("ContinueRevive", 2);
	}
	
	private void ContinueRevive()
	{

		transform.position = spawnpoint.transform.position;
		transform.rotation = spawnpoint.transform.rotation;
		GetComponent<Animator>().enabled = true;
		GetComponent<CharacterController>().enabled = true;
		
		//Debug.Log(transform.position);
	}
}
