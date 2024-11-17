using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public float HP = 100;
    public float Fullness = 100;
    public float stamina = 50;
    public int AtkPower = 20;

    public float radius = 0.5f;
    bool ishunger = false;
    public bool isSliderOn = false;

    public Image HPImg;
    public Image FullImag;
    public Slider StaminaBar;

    public GameObject DeadScene;

    private PlayerMovement playerMovement;

    public LayerMask layer;
    private Collider[] colliders;

    

    void Start()
    {
        StaminaBar.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
        StaminaBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);

        StartCoroutine(healStatus());
    }
    void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, radius, layer);
        if (Input.GetMouseButtonDown(0)) { Attacked(); }
    }

    public void Attacked()
    {
        foreach(var g in colliders)
        {
            g.GetComponent<MonsterState>().Damaged(AtkPower);
        }
    }
    public void Damage()
    {
        HP -= 15;
        HPImg.color = new Color(1, 0, 0, HPImg.color.a + 0.05f);
        if (HP <= 0) Dead();
    }
    public void Eat(int fullness)
    {
        
        if (Fullness < 30) ishunger = true;

         Fullness += fullness;
        if (Fullness > 100) Fullness = 100;
        if(ishunger == true && Fullness >= 30) { StartCoroutine(healStatus()); ishunger = false; }
        
    }
    
    public void BarOn()
    {
        StaminaBar.value = stamina;
        StaminaBar.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }
    public void Baroff()
    {
        StartCoroutine(BarOff());
    }
    IEnumerator BarOff()
    {
        
        isSliderOn = false;
        //yield return new WaitForSeconds(3f);
        if (playerMovement.isRunning == true) yield break;

        float a = 1;

        while (StaminaBar.transform.GetChild(0).GetComponent<Image>().color.a >= 0
            && playerMovement.isRunning == false)
        {
            if (playerMovement.isRunning == true) break;

            yield return new WaitForSeconds(0.1f);

            StaminaBar.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, a);
            StaminaBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, a);
            a -= 0.03f;
        }
        StaminaBar.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        StaminaBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        yield break;
        
    }
    public IEnumerator healStatus()
    {
        while(Fullness >= 30)
        {
            HP += 0.3f;
            if (HP > 100) HP = 10;
            stamina += 0.5f;
            StaminaBar.value += 0.005f;
            if (stamina > 100) stamina = 100;

            Fullness -= 0.025f;
            if (Fullness < 0) Fullness = 0;

            yield return new WaitForSeconds(0.1f);
        }
        
    }


    public void Dead()
    {

    }
    public void Save()
    {

    }
}
