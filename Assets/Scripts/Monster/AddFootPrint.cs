using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFootPrint : MonoBehaviour
{
    public GameObject[] footPrints;
    Transform parent;
    bool isRight;
    bool isPrint = false;
    // Start is called before the first frame update

    private void Update()
    {
        if(parent.childCount <= 50 && isPrint == false)
        {
            StartCoroutine(PrintFoot());
            isPrint = true;
        }
    }
    IEnumerator PrintFoot()
    {
        while (parent.childCount <= 50)
        {
            if (isRight)
                Instantiate(footPrints[1], this.gameObject.transform.position, Quaternion.identity, parent);
            else Instantiate(footPrints[0], this.gameObject.transform.position, Quaternion.identity, parent);

            yield return new WaitForSeconds(10f);
        }
        isPrint = false;
    }
}
