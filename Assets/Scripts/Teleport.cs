using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public int lastIndex;
    public string SceneName;

    private void OnCollisionEnter(Collision collision)
    {
        if(lastIndex == -1) SceneManager.LoadScene(SceneName);
        else if (Puzzle.Instance.isClear[lastIndex])
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
