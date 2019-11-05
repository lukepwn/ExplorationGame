using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public GameObject goldText;
    private int goldNumber;

    // Start is called before the first frame update
    void Start()
    {
        goldNumber = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            goldText.GetComponent<GoldText>().goldCount += goldNumber;
            Destroy(this.gameObject);
        }
    }
}
