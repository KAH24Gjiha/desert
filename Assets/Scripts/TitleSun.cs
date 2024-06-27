using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSun : MonoBehaviour
{
    public Light sun;  // 씬에서 Directional Light를 할당합니다.
    public Material currentSkybox;

    void Start()
    { 
        //currentSkybox = new Material(Shader.Find("Skybox/Procedural"));

        sun.transform.rotation = Quaternion.Euler(new Vector3(10f, 170f, 0f));
        //Debug.Log(sun.transform.rotation);

        //sun.color = new Color(220, 140, 120);
    }
}
