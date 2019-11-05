using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int goldNumber;

    // Start is called before the first frame update
    void Start()
    {
        // between 1 and 2
        goldNumber = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Inventory>().gold += goldNumber;
            Destroy(this.gameObject);
        }
    }
}
