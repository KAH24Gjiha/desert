using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    private static Puzzle instance = null;
    public bool[] isClear = new bool[3];

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static Puzzle Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void Clear(int index)
    {
        isClear[index] = true;
    }
    public bool IsPuzzleClear(int index)
    {
        return isClear[index];
    }
}
