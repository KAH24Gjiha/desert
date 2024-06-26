<<<<<<< HEAD:DesertQuest/Assets/Scripts/Item/Inventory.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public List<Item> InvenList = new List<Item>();

}
=======
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
>>>>>>> 65d51948a86366ec6d31944ab5cdf7f181b1470e:Assets/Scripts/Inventory.cs
