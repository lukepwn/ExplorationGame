using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRabbit : MonoBehaviour
{
    public GameObject ShopPanel;

    private int allSlots;
    private int enabledSlots;
    public static GameObject[] slot;

    public GameObject slotHolder;

    public GameObject[] items = new GameObject[6];
    public Sprite[] itemSprites = new Sprite[6];

    // Start is called before the first frame update
    void Start()
    {

        allSlots = 6;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            // set the slots to the panel's slots
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            // set the slot icons
            slot[i].GetComponent<Slot>().slotIconGO = slot[i].transform.GetChild(0);


            if (slot[i].GetComponent<Slot>().item == null)
            {
                // add item to shopkeeper slots
                slot[i].GetComponent<Slot>().item = items[i];
                slot[i].GetComponent<Slot>().icon = itemSprites[i];
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;

                // set price to 2 - for potions
                if (slot[i].GetComponent<Slot>().item.tag == "Potion")
                {
                    slot[i].GetComponent<Slot>().itemPrice = 2;
                }
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerStay: " + other.transform.name);
            ShopPanel.SetActive(true);
            // turn on inventory 
            ShopPanel.transform.parent.GetChild(0).gameObject.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerExit: " + other.transform.name);
            ShopPanel.SetActive(false);
            // turn off inventory 
            ShopPanel.transform.parent.GetChild(0).gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
