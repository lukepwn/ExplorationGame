using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        item = this.transform.parent.gameObject.GetComponent<Slot>().item;
        Debug.Log("item: " + item.transform.name);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
