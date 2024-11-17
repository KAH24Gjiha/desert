using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterState : MonoBehaviour
{
    public int hp;
    [SerializeField] private GameObject dropItem;
    [SerializeField] private Transform parent;

    private void Start()
    {
        parent = GameObject.Find("Object").transform;
    }
    public void Damaged(int damage)
    {
        hp -= damage;
        if (hp <= 0) death();
    }
    public void death()
    {
        Instantiate(dropItem, this.transform.position, this.transform.rotation, parent);
        Destroy(this.gameObject);
    }
}
