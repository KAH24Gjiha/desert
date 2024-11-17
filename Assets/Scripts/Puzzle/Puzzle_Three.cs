using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Three : MonoBehaviour
{
    public GameObject gate;

    public void IsFinished()
    {
        Puzzle.Instance.isClear[2] = true;
        gate.SetActive(true);
    }
}
