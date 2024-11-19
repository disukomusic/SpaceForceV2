using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        TaskManager.Instance.AssignTask(0, Random.Range(0, TaskManager.Instance.tasks.Length));
    }
    
}
