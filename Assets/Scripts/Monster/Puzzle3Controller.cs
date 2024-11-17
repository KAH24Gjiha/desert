using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Controller : MonoBehaviour
{
    [SerializeField] private int hp;
    private MonsterState monsterState;
    private Puzzle_Three Puzzle_Three;

    private void Start()
    {
        monsterState = GetComponent<MonsterState>();
    }
    private void Update()
    {
        if (monsterState.hp <= 0)
        {
            Destroy(this.gameObject);
            Puzzle_Three.IsFinished();
        }
    }
}
