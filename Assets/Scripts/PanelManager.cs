using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public List<Task> taskQueue = new List<Task>();
    public List<Task> completedTasks = new List<Task>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnInput();
        }
    }

    void OnInput()
    {
        CheckTaskCompletion("testButton");
    }

    public void CheckTaskCompletion(string input)
    {
        // Iterate through the task queue and check if any task is complete
        for (int i = taskQueue.Count - 1; i >= 0; i--)
        {
            Task task = taskQueue[i];
            if (input == task.taskCompleteCondition)
            {
                completedTasks.Add(task);
                taskQueue.RemoveAt(i);
                Debug.Log($"Task completed: {task.taskName}");
            }
        }
    }
}
