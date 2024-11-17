using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public float radius = 0f;
    public LayerMask layer;
    public Collider[] colliders;

    public Transform parent;
    public GameObject ResultObj;
    public Item thisItem;

    public GameObject player;


    void Start()
    {
        player = GameObject.Find("Player");
        parent = GameObject.Find("ItemGroup").transform;
        layer = LayerMask.NameToLayer("Item");
    }

    void Update()
    {
        if (this.gameObject.CompareTag("Wood"))
        {
            colliders = Physics.OverlapSphere(transform.position, radius, layer);
            IsReach();
        }
    }

    public void IsReach()
    {
        if (this.gameObject.CompareTag("Wood") && colliders.Length >= 3)
            WoodFIre();
    }
    public void WoodFIre()
    {
        Vector3 Pos = GameObject.Find("Player").transform.position;
        Quaternion Rot = GameObject.Find("Player").transform.rotation;

        GameObject items = Instantiate(ResultObj, Pos, Rot);
        items.transform.Translate(0, 1, 2);

        for (int i = 0; i < colliders.Length; i++)
        {
            Destroy(colliders[i].gameObject);
        }
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            if (!this.gameObject.CompareTag("Wood") || this.gameObject.CompareTag("Water"))
            {
                Vector3 Pos = GameObject.Find("Player").transform.position;
                Quaternion Rot = GameObject.Find("Player").transform.rotation;

                GameObject items = Instantiate(ResultObj, Pos, Rot);
                items.transform.Translate(0, 1, 2);

                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            thisItem.Amount++;
            
            GameObject.Find("InventoryManager").GetComponent<InventorySlot>().FreshSlot();
            Destroy(this.gameObject);
        }
        
    }
}
