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
        else
        {
            Vector3 Pos = GameObject.Find("Player").transform.position;
            Quaternion Rot = GameObject.Find("Player").transform.rotation;

            GameObject items = Instantiate(item.item, Pos, Rot);
            items.transform.Translate(0, 1, 2);

        }

        GameObject.Find("InventoryManager").GetComponent<InventorySlot>().FreshSlot();
    }

}

