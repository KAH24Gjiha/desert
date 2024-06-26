using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public List<Item> InvenList = new List<Item>();

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private InvenSlot[] slots;

#if UNITY_EDITOR
    private void Awake()
    {
        //DataManager.Instance.LoadGameData();
        
        slots = slotParent.GetComponentsInChildren<InvenSlot>();
    }
#endif
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
        for (i = 0; i < InvenList.Count; i++)
        {
            if (InvenList[i] != null)
            {
                slots[i].item = InvenList[i];
                //Debug.Log("아이템 : " + inven.InvenList[i].ItemName + " " + inven.InvenList[i].count);
            }
        }
        //slots[i + 1].item = DataManager.Instance.gameData.InvenList[i + 1];
    }

    public void AddItem(Item _item)
    {
        InvenList.Add(_item);
    }

    public void DeleteItem()
    {
        for (int i = 0; i < InvenList.Count; i++)
        {
            if (InvenList[i] != null && InvenList[i].Amount <= 0)
            {
                //Debug.Log("지워짐" + DataManager.Instance.gameData.InvenList[i]);
                InvenList.Remove(InvenList[i]);
                
            }
        }
        
    }
    IEnumerator addFresh()
    {
        yield return new WaitForFixedUpdate();
        FreshSlot();
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public List<Item> Inventory = new List<Item>();

    public ItemDatabase itemData;
    public Image image;
    public Sprite ClearImage;
    public TMP_Text text;

    public int preCount;
    // Start is called before the first frame update
    void Start()
    {
        itemData = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Inventory.Count == preCount)
        {
            Debug.Log("변동 없음");
        }
        else
        {
            preCount = Inventory.Count;
            addItem();
            deleteItem();
            ShowInventory();
            
        }
    }
    public void addItem()
    {
        Debug.Log("추가됨");
        for (int i = 1; i < itemData.itemDB.Count; i++)
        {

            if (itemData.itemDB[i].count > 0)
            {
                if (Inventory.Contains(itemData.itemDB[i]))
                {
                    Debug.Log("중복");
                }
                else
                {
                    Item item = new Item();
                    item.ItemName = itemData.itemDB[i].ItemName;
                    item.category = itemData.itemDB[i].category;
                    item.ItemImage = itemData.itemDB[i].ItemImage;
                    item.UnLocked = itemData.itemDB[i].UnLocked;
                    item.count = itemData.itemDB[i].count;
                    item.ItemNumber = itemData.itemDB[i].ItemNumber;
                    item.recipy = itemData.itemDB[i].recipy;
                    Inventory.Add(item);
                }
            }
        }
    }
    public void deleteItem()
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].count <= 0)
            {
                Inventory.RemoveAt(i);
            }
        }
    }
    public void ShowInventory()
    {
        int n = 0;
        for (int i = 1; i < Inventory.Count; i++)
        {
            string ObjName = "slot (" + n + ")";
            image = GameObject.Find(ObjName).transform.Find("Image").GetComponent<Image>();
            text = GameObject.Find(ObjName).transform.Find("Text").GetComponent<TMP_Text>();

            image.sprite = ClearImage;
            text.text = "   ";
        }
            
        for (int i = 1; i < Inventory.Count; i++)
        {
            
            string ObjName = "slot (" + n + ")";
            image = GameObject.Find(ObjName).transform.Find("Image").GetComponent<Image>();
            text = GameObject.Find(ObjName).transform.Find("Text").GetComponent<TMP_Text>();

            image.sprite = Inventory[i].ItemImage;
            text.text = Inventory[i].count.ToString();
            n++;
        }
    }
}
*/