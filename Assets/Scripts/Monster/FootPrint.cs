using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrint : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delete());
    }

    // Update is called once per frame
    public IEnumerator Delete()
    {
        yield return new WaitForSeconds(300);
        Destroy(this.gameObject);
        
    }
}
