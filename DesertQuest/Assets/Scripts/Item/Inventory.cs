using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> InvenList = new List<Item>();


    static Inventory instance;
    static GameObject container;
    // Start is called before the first frame update
    public static Inventory Instance
    {
        get
        {
            if (!instance)
            {
                container = new GameObject();
                container.name = "Inventory";
                instance = container.AddComponent(typeof(Inventory)) as Inventory;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }
}
