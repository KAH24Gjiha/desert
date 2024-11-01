using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript : MonoBehaviour
{
    [SerializeField] private ShowUI showUI;
    void Start()
    {
        showUI.pauseW.SetActive(false);
        showUI.invenW.SetActive(false);
        showUI.optionW.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
