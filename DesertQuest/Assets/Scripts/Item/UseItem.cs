using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public Item item;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ItemClick()
    {
        this.gameObject.SetActive(true);
        this.GetComponent<InvenSlot>().item = item;
    }
    public void Use()
    {
        item.Amount--;
        GameObject.Find("Player").GetComponent<PlayerState>().Eat(item.fullness);
        GameObject.Find("InventoryManager").GetComponent<InventorySlot>().FreshSlot();
    }
    public void chuck()
    {
        item.Amount--;
        //3D µå¶ø
        GameObject.Find("InventoryManager").GetComponent<InventorySlot>().FreshSlot();
    }
}
