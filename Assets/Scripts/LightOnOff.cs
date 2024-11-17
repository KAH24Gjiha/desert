using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(twinkling());
    }
    IEnumerator twinkling()
    {
        int i = 0;
        while (i <= 30)
        {
            yield return new WaitForSeconds(2f);
            light.intensity = 3;
            yield return new WaitForSeconds(2f);
            light.intensity = 0;

            i++;
        }
    }
}
