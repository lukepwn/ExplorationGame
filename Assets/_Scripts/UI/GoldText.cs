﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldText : MonoBehaviour
{
    private Text gold;
    public int goldCount;

    // Start is called before the first frame update
    void Start()
    {
        goldCount = 0;
        gold = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = goldCount.ToString();
    }
}
