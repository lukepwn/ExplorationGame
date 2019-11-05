using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldText : MonoBehaviour
{
    public GameObject player;
    private Text gold;

    // Start is called before the first frame update
    void Start()
    {
        gold = GetComponent<Text>();
        gold.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = player.GetComponent<Inventory>().gold.ToString();
    }
}
