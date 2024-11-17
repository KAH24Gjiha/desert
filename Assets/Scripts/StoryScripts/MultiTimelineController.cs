using UnityEngine;
using UnityEngine.Playables;

public class MultiTimelineController : MonoBehaviour
{
    public PlayableDirector[] playableDirectors; 

    void Start()
    {
        foreach (var director in playableDirectors)
        {
            if (director != null)
            {
                director.Stop();
            }
        }

        playableDirectors[4].stopped += _ => playableDirectors[5].Play();
    }

    public void PlayTimeline(int index)
    {
        if (index >= 0 && index < playableDirectors.Length)
        {
            PlayableDirector director = playableDirectors[index];
            if (director != null)
            {
                director.Play();
                Debug.Log($"{index} 실행");
            }
        }
        else
        {
            Debug.LogError("index error");
        }
    }

    public void StopTimeline(int index)
    {
        if (index >= 0 && index < playableDirectors.Length)
        {
            PlayableDirector director = playableDirectors[index];
            if (director != null)
            {
                director.Stop();
                Debug.Log($"{index} 정지");
            }
        }
        else
        {
            Debug.LogError("index error");
        }
    }

    public void StopAllTimelines()
    {
        foreach (var director in playableDirectors)
        {
            if (director != null)
            {
                director.Stop();
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) 
        {
            PlayTimeline(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            PlayTimeline(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayTimeline(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayTimeline(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayTimeline(4);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllTimelines();
        }
    }

}
