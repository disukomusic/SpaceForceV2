using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public List<Task> taskQueue = new List<Task>();
    public List<Task> completedTasks = new List<Task>();

    public GameObject taskQueuePanel;
    
    public void CheckTaskCompletion(string input)
    {
        for (int i = taskQueue.Count - 1; i >= 0; i--)
        {
            Task task = taskQueue[i];
            if (input == task.taskCompleteCondition)
            {
                completedTasks.Add(task);
                taskQueue.RemoveAt(i);

                // Notify TaskManager to remove the prefab
                TaskManager.Instance.CompleteTaskPrefab(task);

                Debug.Log($"Task completed: {task.taskName}");
            }
        }
    }
}

