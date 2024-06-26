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
