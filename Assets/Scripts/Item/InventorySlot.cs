using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Inventory InventoryObj;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private InvenSlot[] slots;


    private void Awake()
    {
        //DataManager.Instance.LoadGameData();
        slots = slotParent.GetComponentsInChildren<InvenSlot>();
    }
    void Start()
    {
        StartCoroutine("addFresh");
    }


    public void FreshSlot()
    {
         DeleteItem();
        int i = 0;
        for (; i < slots.Length && i < slots.Length; i++)
        {
            slots[i].item = null;
        }
        for (i = 0; i < InventoryObj.InvenList.Count; i++)
        {
            if (InventoryObj.InvenList[i] != null)
            {
                slots[i].item = InventoryObj.InvenList[i];
                //Debug.Log("아이템 : " + inven.InvenList[i].ItemName + " " + inven.InvenList[i].count);
            }
        }
        //slots[i + 1].item = DataManager.Instance.gameData.InvenList[i + 1];
    }

    public void AddItem(Item _item)
    {
        InventoryObj.InvenList.Add(_item);
    }

    public void DeleteItem()
    {
        for (int i = 0; i < InventoryObj.InvenList.Count; i++)
        {
            if (InventoryObj.InvenList[i] != null && InventoryObj.InvenList[i].Amount <= 0)
            {
                //Debug.Log("지워짐" + DataManager.Instance.gameData.InvenList[i]);
                InventoryObj.InvenList.Remove(InventoryObj.InvenList[i]);
                
            }
        }
        
    }
    IEnumerator addFresh()
    {
        yield return new WaitForFixedUpdate();
        FreshSlot();
    }
}

