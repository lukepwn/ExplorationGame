using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public bool empty;

    public Transform slotIconGO;
    public Sprite icon;

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }
	
	public void RemoveSlot() 
	{
		slotIconGO.GetComponent<Image>().sprite = null;
	}

    // Start is called before the first frame update
    void Start()
    {
        slotIconGO = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
