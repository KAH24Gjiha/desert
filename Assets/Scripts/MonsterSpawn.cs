using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    private Transform player;
    public Transform parent;
    public GameObject[] monster;

    bool isSpawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if(parent.childCount <= 30 && isSpawn == false)
        {
            StartCoroutine(Spawn());
            isSpawn = true;
        }
    }
    IEnumerator Spawn()
    {
        while (parent.childCount <= 30)
        {
            yield return new WaitForSeconds(30f);
            foreach(var i in monster)
            {
                Instantiate(i, player.position + new Vector3(-10, 20, -10), Quaternion.identity, parent);
            }


        }
        isSpawn = false;
    }
}
