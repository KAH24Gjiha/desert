using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public Item[] items;
    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void Save()
    {
        //인벤토리
        PlayerPrefs.SetInt("wolf", items[0].Amount);
        PlayerPrefs.SetInt("wolfC", items[1].Amount);
        PlayerPrefs.SetInt("fox", items[2].Amount);
        PlayerPrefs.SetInt("foxC", items[3].Amount);
        PlayerPrefs.SetInt("rabbit", items[4].Amount);
        PlayerPrefs.SetInt("rabbitC", items[5].Amount);
        PlayerPrefs.SetInt("wood", items[6].Amount);


        //퀘스트클리어여부
        PlayerPrefs.SetInt("isClear1", Puzzle.Instance.isClear[0] ? 1 : 0);
        PlayerPrefs.SetInt("isClear2", Puzzle.Instance.isClear[1] ? 1 : 0);
        PlayerPrefs.SetInt("isClear3", Puzzle.Instance.isClear[2] ? 1 : 0);
    }
    void Load()
    {
        items[0].Amount = PlayerPrefs.GetInt("wolf");
        items[1].Amount = PlayerPrefs.GetInt("wolfC");
        items[2].Amount = PlayerPrefs.GetInt("fox");
        items[3].Amount = PlayerPrefs.GetInt("foxC");
        items[4].Amount = PlayerPrefs.GetInt("rabbit");
        items[5].Amount = PlayerPrefs.GetInt("rabbitC");
        items[6].Amount = PlayerPrefs.GetInt("wood");


        //퀘스트클리어여부
        Puzzle.Instance.isClear[0] = PlayerPrefs.GetInt("isClear1") == 1 ? true : false;
        Puzzle.Instance.isClear[1] = PlayerPrefs.GetInt("isClear2") == 1 ? true : false;
        Puzzle.Instance.isClear[2] = PlayerPrefs.GetInt("isClear3") == 1 ? true : false;
    }
}
