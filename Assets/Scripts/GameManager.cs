using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public bool isPlaying;
    public float shipHealth;
    private void Start()
    {
        isPlaying = true;
        ActivateDisplays();
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

    /// <summary>
    /// https://docs.unity3d.com/2019.3/Documentation/Manual/MultiDisplay.html
    /// </summary>
    void ActivateDisplays()
    {
        Debug.Log ("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON, so start at index 1.
        // Check if additional displays are available and activate each.
    
        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
}
