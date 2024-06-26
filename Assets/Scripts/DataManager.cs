using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
    static GameObject container;
    public int COIN;

    static DataManager instance;

    //[SerializeField] public static List<Item> itemList = new List<Item>();
    public static DataManager Instance
    {
        get
        {
            if (!instance)
            {
                container = new GameObject();
                container.name = "DataManager";
                instance = container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }

    string GameDataFileName = "GameData.json";

    public GameData gameData = new GameData();

    // �ҷ�����
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        //Debug.Log(filePath);

        if (File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(FromJsonData);
            Debug.Log("�ҷ����� �Ϸ�");

            //LoadInven();
            //itemList = Instance.gameData.InvenList;
        }
        else {
            Debug.Log("�ҷ����� ����");
        }
    }

    // �����ϱ�
    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        //string jsonString = JsonConvert.SerializeObject(gameData);
        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("���� �Ϸ�");
    }
    public void DeleteGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        System.IO.File.Delete(filePath);

    }

    
    private void Awake()
    {
        //SaveGameData();
        LoadGameData();
    }

   
}