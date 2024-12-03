using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public bool isPlaying;
    private void Start()
    {
        isPlaying = true;
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        while (isPlaying)
        {
            TaskManager.Instance.AssignTask(0, Random.Range(0, TaskManager.Instance.tasks.Length));
            yield return new WaitForSeconds(1f);
            TaskManager.Instance.AssignTask(1, Random.Range(0, TaskManager.Instance.tasks.Length));
            yield return new WaitForSeconds(1f);
            TaskManager.Instance.AssignTask(2, Random.Range(0, TaskManager.Instance.tasks.Length));
            yield return new WaitForSeconds(1f);
            
        }   
    }
}
