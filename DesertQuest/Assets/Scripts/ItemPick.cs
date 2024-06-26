using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    public Item item;
    public UseItem UseSlots;
    public InventorySlot InventoryS;
    // Start is called before the first frame update
    void Start()
    {
        InventoryS = GameObject.Find("InventoryManager").GetComponent<InventorySlot>();

    }

    // Update is called once per frame
    public void GetItem()
    {
        if(item.Amount <= 0)
            InventoryS.AddItem(item);
        item.Amount++;
        InventoryS.FreshSlot();
    }
    public void Picked()
    {
        item = this.GetComponent<InvenSlot>().item;
        if (item != null)
        {
            UseSlots.item = item;
            UseSlots.ItemClick();
        }
    }

}
