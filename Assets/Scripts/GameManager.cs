using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public bool isPlaying;
    public float shipHealth;
    public float score;
    public PlayerData playerData;

    public static GameManager Instance;

    public RectTransform[] shipHealthBars;

    public AudioSource lowHealthSound;

    private bool _alarmPlaying;
    
    // Task timing variables
    public float initialMinInterval = 4f;
    public float initialMaxInterval = 6f;
    public float minIntervalCap = 1f;
    public float maxIntervalCap = 3f;
    public float intervalDecreaseRate = 0.1f;

    public float _currentMinInterval;
    public float _currentMaxInterval;
    
    public TMP_Text[] scoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isPlaying = true;
        StartCoroutine(GameLoop());
        _currentMaxInterval = initialMaxInterval;
        _currentMinInterval = initialMinInterval;
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

        if (shipHealth <= 20 && !_alarmPlaying)
        {
            LowHealthSound();
        }
        if (shipHealth <= 0)
        {
            GameOver();
        }
    }

    public void UpdateScoreText()
    {
        foreach (TMP_Text text in scoreText)
        {
            text.text = score.ToString();
        }
    }
    
    private void GameOver()
    {
        Debug.Log("Game Over");
        isPlaying = false;

        // Save the score to the PlayerData scriptable object
        if (playerData != null)
        {
            playerData.score = score; // Convert float to int if needed
            Debug.Log("Score saved to PlayerData: " + playerData.score);
        }

        // Optionally, load another scene or restart the game
        SceneManager.LoadScene("EndScreen");
    }

    IEnumerator GameLoop()
    {
        while (isPlaying)
        {
            TaskManager.Instance.AssignTask(0, Random.Range(0, TaskManager.Instance.tasks.Length));
            yield return new WaitForSeconds(Random.Range(_currentMinInterval, _currentMaxInterval));
            
            TaskManager.Instance.AssignTask(1, Random.Range(0, TaskManager.Instance.tasks.Length));
            yield return new WaitForSeconds(Random.Range(_currentMinInterval, _currentMaxInterval));
            
            TaskManager.Instance.AssignTask(2, Random.Range(0, TaskManager.Instance.tasks.Length));
            yield return new WaitForSeconds(Random.Range(_currentMinInterval, _currentMaxInterval));

            // Decrease intervals over time, clamping to the minimum cap
            _currentMinInterval = Mathf.Max(minIntervalCap, _currentMinInterval - intervalDecreaseRate * Time.deltaTime);
            _currentMaxInterval = Mathf.Max(maxIntervalCap, _currentMaxInterval - intervalDecreaseRate * Time.deltaTime);
        }   
    }


    void LowHealthSound()
    {
        lowHealthSound.Play();
        _alarmPlaying = true;
    }


}
