using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoCollider : MonoBehaviour
{
    private MonsterController monsterController;
    private Puzzle_two puzzleTwo;
    // Start is called before the first frame update
    void Start()
    {
        puzzleTwo = GameObject.Find("PuzzleManager").GetComponent<Puzzle_two>();
        monsterController = GetComponent<MonsterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(monsterController.hp <= 0)
        {
            puzzleTwo.deathCount++;
            Destroy(this.gameObject);
        }
    }
}
