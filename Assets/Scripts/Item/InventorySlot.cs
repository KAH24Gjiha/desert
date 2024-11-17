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
        int i = 0;

        for (i = 0; i < InventoryObj.InvenList.Length; i++)
        {
            if (InventoryObj.InvenList[i].Amount > 0)
            {
                slots[i].item = InventoryObj.InvenList[i];
                //Debug.Log("æ∆¿Ã≈€ : " + inven.InvenList[i].ItemName + " " + inven.InvenList[i].count);
            }
        }
        //slots[i + 1].item = DataManager.Instance.gameData.InvenList[i + 1];
    }
    IEnumerator addFresh()
    {
        yield return new WaitForFixedUpdate();
        FreshSlot();
    }
}

