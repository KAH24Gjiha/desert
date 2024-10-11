using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject pauseW;
    public GameObject invenW;
    public GameObject optionW;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        pauseW.SetActive(false);
        invenW.SetActive(false);
        optionW.SetActive(false);
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (optionW.activeSelf == true) OptionWindow(false);
            else if (invenW.activeSelf == true) InventoryWindow(false); //인벤토리 (같이 꺼지지 앟ㄴ게 else로 해둠)
            else if (pauseW.activeSelf == false && optionW.activeSelf == false) PauseWindow(true);

            else PauseWindow(false);

            

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (invenW.activeSelf == false&& pauseW.activeSelf == false) InventoryWindow(true);
            else if (invenW.activeSelf == true) InventoryWindow(false);
        }
    }

    public void PauseWindow(bool active)
    {
        pauseW.SetActive(active);
    }
    public void InventoryWindow(bool active)
    {
        invenW.SetActive(active);
    }
    public void OptionWindow(bool active)
    {
        optionW.SetActive(active);
    }
}
