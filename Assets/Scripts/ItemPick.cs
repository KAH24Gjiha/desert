<<<<<<< HEAD:DesertQuest/Assets/Scripts/ItemPick.cs
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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GetItem()
    {
        if(item.Amount <= 0)
            GameObject.Find("InventoryManager").GetComponent<InventorySlot>().AddItem(item);
        item.Amount++;
        GameObject.Find("InventoryManager").GetComponent<InventorySlot>().FreshSlot();
    }
    public void DelItem()
    {
        item.Amount--;
        GameObject.Find("InventoryManager").GetComponent<InventorySlot>().FreshSlot();
    }
}
>>>>>>> 65d51948a86366ec6d31944ab5cdf7f181b1470e:Assets/Scripts/ItemPick.cs
