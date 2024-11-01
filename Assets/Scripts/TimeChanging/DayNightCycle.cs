using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;  // 씬에서 Directional Light를 할당합니다.
    public float dayDuration = 30f;  // 하루의 지속 시간(초)
    [SerializeField] public Material daySkybox;  // 낮 Skybox Material
    [SerializeField] public Material nightSkybox;  // 밤 Skybox Material
    public bool isNightTime = false;
    public float transitionSpeed = 1f;  // Skybox 전환 속도
    public float time;
    public float timeRatio;
    public Material currentSkybox; 

    public GameObject monsterSpawnerObject;
    MonsterSpawner monsterSpawner;

    [SerializeField] private bool isPlayingStory;
    public GameObject storyManagerObj;

    void Start()
    {
        monsterSpawner = monsterSpawnerObject.GetComponent<MonsterSpawner>();
        //currentSkybox = new Material(Shader.Find("Skybox/Procedural"));
        RenderSettings.skybox = currentSkybox;
        time = 15f;
    }

    void Update()
    {
        while (!isPlayingStory)
        {
            // 시간 업데이트
            time += Time.deltaTime;
        }
        if (time > dayDuration) time = 0;

        // 현재 시간 비율 계산 (0에서 1 사이)
        timeRatio = time / dayDuration;

        // 태양의 각도 설정 (360도 회전)
        float sunAngle = timeRatio * 360f;
        sun.transform.rotation = Quaternion.Euler(new Vector3(sunAngle - 90f, 170f, 0f));

        // 조명의 색상과 강도 변경
        //float intensity;
        Color sunColor;
        if (timeRatio < 0.25f || timeRatio > 0.75f)
        {
            // 밤
            if (!isNightTime)
            {
                isNightTime = true;
                Debug.Log("T");
                isPlayingStory = storyManagerObj.GetComponent<StoryManage>().isPlayingStory;
                if (!isPlayingStory) monsterSpawner.StartMonsterSpawnCoroutine(3);
            }
            //intensity = Mathf.Lerp(0f, 1f, Mathf.InverseLerp(0.75f, 1f, timeRatio) + Mathf.InverseLerp(0f, 0.25f, timeRatio));
            sunColor = Color.Lerp(Color.black, new Color(230, 55, 0), Mathf.InverseLerp(0.75f, 1f, timeRatio) + Mathf.InverseLerp(0f, 0.25f, timeRatio));
        }
        else
        {
            // 낮
            if (isNightTime)
            {
                isNightTime = false;
                Debug.Log("F");
                monsterSpawner.StopMonsterSpawnCoroutine();
            }
            //intensity = Mathf.Lerp(0f, 1f, Mathf.InverseLerp(0.25f, 0.5f, timeRatio) + Mathf.InverseLerp(0.5f, 0.75f, timeRatio));
            sunColor = Color.Lerp(Color.red, new Color(230, 55, 0), Mathf.InverseLerp(0.25f, 0.5f, timeRatio) + Mathf.InverseLerp(0.5f, 0.75f, timeRatio));
        }
        //sun.intensity = intensity;
        sun.color = new Color(230, 55, 0);

        // Skybox 전환
        float lerpFactor;
        if (timeRatio < 0.25f)
        {
            lerpFactor = timeRatio / 0.25f;
            BlendSkybox(nightSkybox, daySkybox, lerpFactor);
        }
        else if (timeRatio < 0.5f)
        {
            lerpFactor = (timeRatio - 0.25f) / 0.25f;
            BlendSkybox(daySkybox, daySkybox, lerpFactor);
        }
        else if (timeRatio < 0.75f)
        {
            lerpFactor = (timeRatio - 0.5f) / 0.25f;
            BlendSkybox(daySkybox, nightSkybox, lerpFactor);
        }
        else
        {
            lerpFactor = (timeRatio - 0.75f) / 0.25f;
            BlendSkybox(nightSkybox, nightSkybox, lerpFactor);
        }
    }

    void BlendSkybox(Material from, Material to, float lerpFactor)
    {
        currentSkybox.Lerp(from, to, lerpFactor);
    }
}
