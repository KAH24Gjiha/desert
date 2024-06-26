using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;  // ������ Directional Light�� �Ҵ��մϴ�.
    public float dayDuration = 10f;  // �Ϸ��� ���� �ð�(��)
    [SerializeField] public Material daySkybox;  // �� Skybox Material
    [SerializeField] public Material nightSkybox;  // �� Skybox Material
    public bool isNightTime = false;
    public float transitionSpeed = 1f;  // Skybox ��ȯ �ӵ�
    private float time;
    private Material currentSkybox; 

    public GameObject monsterSpawnerObject;
    MonsterSpawner monsterSpawner;

    void Start()
    {
        monsterSpawner = monsterSpawnerObject.GetComponent<MonsterSpawner>();
        currentSkybox = new Material(Shader.Find("Skybox/Procedural"));
        RenderSettings.skybox = currentSkybox;
    }

    void Update()
    {
        // �ð� ������Ʈ
        time += Time.deltaTime;
        if (time > dayDuration) time = 0;

        // ���� �ð� ���� ��� (0���� 1 ����)
        float timeRatio = time / dayDuration;

        // �¾��� ���� ���� (360�� ȸ��)
        float sunAngle = timeRatio * 360f;
        sun.transform.rotation = Quaternion.Euler(new Vector3(sunAngle - 90f, 170f, 0f));

        // ������ ����� ���� ����
        float intensity;
        Color sunColor;
        if (timeRatio < 0.25f || timeRatio > 0.75f)
        {
            // ��
            if (!isNightTime)
            {
                isNightTime = true;
                Debug.Log("T");
                monsterSpawner.StartMonsterSpawnCoroutine(3);
            }
            intensity = Mathf.Lerp(0f, 1f, Mathf.InverseLerp(0.75f, 1f, timeRatio) + Mathf.InverseLerp(0f, 0.25f, timeRatio));
            sunColor = Color.Lerp(Color.black, Color.blue, Mathf.InverseLerp(0.75f, 1f, timeRatio) + Mathf.InverseLerp(0f, 0.25f, timeRatio));
        }
        else
        {
            // ��
            if (isNightTime)
            {
                isNightTime = false;
                Debug.Log("F");
                monsterSpawner.StopMonsterSpawnCoroutine();
            }
            intensity = Mathf.Lerp(0f, 1f, Mathf.InverseLerp(0.25f, 0.5f, timeRatio) + Mathf.InverseLerp(0.5f, 0.75f, timeRatio));
            sunColor = Color.Lerp(Color.blue, Color.white, Mathf.InverseLerp(0.25f, 0.5f, timeRatio) + Mathf.InverseLerp(0.5f, 0.75f, timeRatio));
        }
        sun.intensity = intensity;
        sun.color = sunColor;

        // Skybox ��ȯ
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
