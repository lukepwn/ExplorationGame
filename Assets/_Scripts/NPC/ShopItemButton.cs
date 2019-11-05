using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{
    public GameObject item;
    public GameObject player;

    private int itemPrice;
    private GameObject thisSlot;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        // retrieve item from store
        item = this.transform.parent.gameObject.GetComponent<Slot>().item;

        // retreive item price from slot
        itemPrice = this.transform.parent.gameObject.GetComponent<Slot>().itemPrice;

        // slot reference
        thisSlot = this.transform.parent.gameObject;
    }

    void TaskOnClick()
    {
        // if player has more gold than item price
        if (player.GetComponent<Inventory>().gold >= itemPrice)
        {
            // add item to inventory
            player.GetComponent<Inventory>().AddItem(item, this.transform.parent.gameObject.GetComponent<Slot>().icon);
            // update gold
            player.GetComponent<Inventory>().gold -= itemPrice;
            // remove slot from shop
            thisSlot.GetComponent<Slot>().RemoveSlot();
            // disable button
            this.GetComponent<Button>().enabled = false;
        }
        else
        {
            this.transform.root.Find("Shop").Find("NotEnoughGold").gameObject.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
