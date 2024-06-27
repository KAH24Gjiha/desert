using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvenSlot : MonoBehaviour
{
    [SerializeField] Image image;
    public TMP_Text NameText;
    public TMP_Text AmountText;
    [SerializeField]
    private Item _item;

    void Awake() {
        
    }

    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = _item.sprite;
                NameText.text = _item.Name.ToString();
                AmountText.text = _item.Amount.ToString();

                //text.text = DataManager.Instance.gameData.MaterialCount[item.ItemName].ToString();
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
                NameText.text = " ";
                AmountText.text = " ";
            }
        }
    }
}
