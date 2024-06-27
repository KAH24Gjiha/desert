using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrint : MonoBehaviour
{

    public GameObject footPrint;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("ItemGroup").transform;
        StartCoroutine(Print());
    }

    // Update is called once per frame
    public IEnumerator Print()
    {
        Instantiate(footPrint, this.transform.position, this.transform.rotation, parent);
        yield return new WaitForSeconds(60);
    }
}
