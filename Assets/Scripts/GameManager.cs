using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public bool isPlaying;
    public float shipHealth;

    public static GameManager Instance;

    public RectTransform[] shipHealthBars;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isPlaying = true;
        ActivateDisplays();
        StartCoroutine(GameLoop());
        shipHealth = 100f;
    }

    private void Update()
    {
        foreach(RectTransform i in shipHealthBars)
        {
            float newWidth = Mathf.Lerp(0, 710, shipHealth/100f);
        
            var sizeDelta = i.sizeDelta;
            sizeDelta.x = newWidth;
            i.sizeDelta = sizeDelta;
        }
        
        if (shipHealth <= 0)
        {
            Debug.Log("Game Over");
            isPlaying = false;
        }
    }

    IEnumerator GameLoop()
    {
        while (isPlaying)
        {
            TaskManager.Instance.AssignTask(0, Random.Range(0, TaskManager.Instance.tasks.Length));
            yield return new WaitForSeconds(1f);
            TaskManager.Instance.AssignTask(1, Random.Range(0, TaskManager.Instance.tasks.Length));
            yield return new WaitForSeconds(5f);
            TaskManager.Instance.AssignTask(2, Random.Range(0, TaskManager.Instance.tasks.Length));
            yield return new WaitForSeconds(5f);
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
