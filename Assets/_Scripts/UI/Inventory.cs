using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;
	
    public GameObject inventory;

    private int allSlots;
    private int enabledSlots;
    public static GameObject[] slot;
	

    public GameObject slotHolder;
	
	public Transform targetBone;

    // Start is called before the first frame update
    void Start()
    {
        allSlots = 6;
        slot = new GameObject[allSlots];

        for(int i=0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if(slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
                // set slot icons
                slot[i].GetComponent<Slot>().slotIconGO = slot[i].transform.GetChild(0);
            }
        }
    }
	
	private void Toggle() 
	{
		if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;

            if (inventoryEnabled == true)
            {
                inventory.SetActive(true);
            }
            else
            {
                inventory.SetActive(false);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("onTriggerEnter: " + other.transform.name);
        if(other.GetComponent<Item>())
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();
			
			itemPickedUp.SetActive(false);

            AddItem(itemPickedUp, item.icon);
			
        }
    }

    public void AddItem(GameObject itemObject, Sprite itemSprite)
    {
        for(int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                // add item to slot
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemSprite;
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;

                return;
            }
        }
    }
	
	private void SelectItem()
    {
        
        //Debug.Log(slot[0].GetComponent<Slot>().item);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(slot[0].GetComponent<Slot>().item != null)
            {
                
                slot[0].GetComponent<Slot>().item.SetActive(true);
                slot[0].GetComponent<Slot>().RemoveSlot();
                slot[0].GetComponent<Slot>().empty = true;
                //Debug.Log(slot[0].GetComponent<Slot>().item);
                
                GameObject newItem;
                newItem = Instantiate(slot[0].GetComponent<Slot>().item, targetBone.position, targetBone.rotation);
                //Debug.Log(targetBone.position);
                //Debug.Log(targetBone.rotation);
                newItem.transform.parent = targetBone;
                
                newItem.GetComponent<BoxCollider>().isTrigger = false;
                newItem.GetComponent<Rigidbody>().isKinematic = true;
                
                Destroy(slot[0].GetComponent<Slot>().item);
            }
        }
        
    }
	
	
	
	
    // Update is called once per frame
    void Update()
    {
        Toggle();
		SelectItem();
    }
}
