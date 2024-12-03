using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour

{
    [Header("Timer Settings")]
    public float timerDuration = 25f;   
    public string nextSceneName;        

    private float timeRemaining;
    private bool timerRunning = false;

    void Start()
    {
        timeRemaining = timerDuration;  
        timerRunning = true;            
    }

    void Update()
    {
        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;  

            if (timeRemaining <= 0)
            {
                timerRunning = false;        
                LoadNextScene();             
            }
        }
    }

  
    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName)) // Make sure a scene name is set
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is not set in the inspector!");
        }
    }
}

