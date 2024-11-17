using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_two : MonoBehaviour
{
    public int deathCount = 0;
    public int condition = 15;

    public GameObject gate;

    public void IsFinished()
    {
        if(deathCount == condition)
        {
            Puzzle.Instance.isClear[1] = true;
            gate.SetActive(true);
        }
    }
}
