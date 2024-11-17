using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    public Item thisItem;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            thisItem.Amount++;

            GameObject.Find("InventoryManager").GetComponent<InventorySlot>().FreshSlot();
            Destroy(this.gameObject);
        }
    }
}
