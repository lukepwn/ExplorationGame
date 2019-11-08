using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{

	void OnTriggerEnter (Collider col)
	{
		
		if (col.gameObject.tag == "Item") 
		{
			Destroy(this.gameObject);
			Destroy(col.gameObject);
		}
	}

}