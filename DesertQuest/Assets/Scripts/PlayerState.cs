using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public float HP = 100;
    public float Fullness = 100;
    public float stamina = 50;
    public int Attacked = 20;

    public Image HPImg;
    public Image FullImag;
    public Slider StaminaBar;

    bool ishunger = false;

    public GameObject DeadScene;


    void Start()
    {
        StaminaBar.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
        StaminaBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);

        StartCoroutine(healStatus());
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
    public void Run(bool TF)
    {
        

        if (TF == true)
        {
            StartCoroutine(run()); 
        }
        else
        {
            StartCoroutine(BarOff());
            StopCoroutine(run()); 
        }
    }
    public IEnumerator run()
    {
        StopCoroutine(BarOff());
        StaminaBar.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        StaminaBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        while (!Input.GetKeyUp(KeyCode.LeftShift) || stamina > 0)
        {
            stamina -= 1;
            StaminaBar.value -= 0.01f;
            yield return new WaitForSeconds(0.1f);
            if (!Input.GetKey(KeyCode.LeftShift)) { StartCoroutine(BarOff()); yield break;}
        }
        yield break;
    }
    IEnumerator BarOff()
    {
        //yield return new WaitForSeconds(3f);
        if (this.GetComponent<PlayerMove>().isRun == true) yield break;

        float a = 1;

        while (StaminaBar.transform.GetChild(0).GetComponent<Image>().color.a >= 0
            && this.GetComponent<PlayerMove>().isRun == false)
        {
            if (this.GetComponent<PlayerMove>().isRun == true) break;
            
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
