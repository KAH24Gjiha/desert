using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneCollider : MonoBehaviour
{
    private Puzzle_one puzzleOne;
    public int[] trueNumber;
    // Start is called before the first frame update
    void Start()
    {
        puzzleOne = GameObject.Find("PuzzleManager").GetComponent<Puzzle_one>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Player"))
        {
            foreach (var i in trueNumber)
                puzzleOne.onLight[i] = !puzzleOne.onLight[i];
            puzzleOne.IsFInished();
        }
    }
}
