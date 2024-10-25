using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_two : MonoBehaviour
{
    public int deathCount = 0;
    public int condition = 15;

    public bool isSuccess;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void IsFinished()
    {
        if(deathCount == condition)
        {
            isSuccess = true;
        }
    }
}
