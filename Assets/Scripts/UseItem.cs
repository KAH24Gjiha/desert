<<<<<<< HEAD:DesertQuest/Assets/Scripts/Item/UseItem.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public Item item;
    public Transform parent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ItemClick()
    {
        this.gameObject.SetActive(true);
    }
    public void Use()
    {
        item.Amount--;
        if (item.IType == Type.food)
            GameObject.Find("Player").GetComponent<PlayerState>().Eat(item.fullness);
        else Instantiate(item.item, GameObject.Find("Player").transform.position, Quaternion.Euler(0,0,0), parent);

        GameObject.Find("InventoryManager").GetComponent<InventorySlot>().FreshSlot();
    }

}
=======
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
>>>>>>> 65d51948a86366ec6d31944ab5cdf7f181b1470e:Assets/Scripts/UseItem.cs
