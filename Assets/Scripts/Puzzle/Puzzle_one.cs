using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_one : MonoBehaviour
{
    public GameObject[] Light;
    public bool[] onLight;

    public GameObject gate;

    public void IsFInished()
    {
        int finish = 0;
        foreach(var i in onLight)
        {
            if (i != true) break;
            else finish++;
        }

        if (finish == onLight.Length)
        {
            Puzzle.Instance.isClear[0] = true;
            gate.SetActive(true);
        }
    }
    public void LightOn()
    {
        for(int i = 0; i < onLight.Length; i++)
        {
            Light[i].SetActive(onLight[i]);
        }
    }
}
