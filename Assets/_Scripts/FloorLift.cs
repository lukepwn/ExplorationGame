using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLift : MonoBehaviour
{
	
	public Transform floor;
    // Start is called before the first frame update
    void Start()
    {
        floor = floor.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter (Collider col) 
	{
		
		//floor.transform.Translate(0, 1, 0);
	}
		
}
