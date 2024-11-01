using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManage : MonoBehaviour
{
    public GameObject dayNightObj;
    DayNightCycle dayNightCycle;

    public bool isPlayingStory;
    private bool isTimeChanging;

    void Start()
    {
        dayNightCycle = dayNightObj.GetComponent<DayNightCycle>();
        isPlayingStory = true;
        isTimeChanging = true;
        dayNightCycle.time = 85;
    }
    void Update()
    {

        while (isTimeChanging)
        {
            dayNightCycle.time += Time.deltaTime;
        }
    }
}
