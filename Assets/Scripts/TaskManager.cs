using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    public PanelManager[] panels;
    public Task[] tasks;

    public GameObject taskPrefab;

    // Dictionary to track the prefab instance for each task
    private Dictionary<Task, GameObject> taskPrefabMap = new Dictionary<Task, GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    public void AssignTask(int panelIndex, int taskIndex)
    {
        Task task = tasks[taskIndex];
        PanelManager panel = panels[panelIndex];

        // Add the task to the queue
        panel.taskQueue.Add(task);

        // Instantiate a unique prefab
        GameObject taskObject = Instantiate(taskPrefab, panel.taskQueuePanel.transform, false);

        // Assign the correct task name to the prefab's text
        TaskContainer taskContainer = taskObject.GetComponent<TaskContainer>();
        taskContainer.SetTask(task, task.taskDescription, task.taskTime, task.taskDamage);

        // Map the task to its prefab instance
        taskPrefabMap[task] = taskObject;

        Debug.Log($"Assigned task {task.taskName} to panel {panel.gameObject.name}");
    }


    public void RemoveTaskPrefab(Task task)
    {
        if (taskPrefabMap.TryGetValue(task, out GameObject taskObject))
        {
            Destroy(taskObject); // Remove the prefab
            taskPrefabMap.Remove(task); // Clean up the dictionary
        }
    }

    public void HandleTaskFailure(Task task)
    {
        if (taskPrefabMap.TryGetValue(task, out GameObject taskObject))
        {
            Destroy(taskObject); // Remove the task's GameObject
            taskPrefabMap.Remove(task); // Clean up the dictionary

            // Find the panel containing the task and remove it from the queue.
            foreach (PanelManager panel in panels)
            {
                if (panel.taskQueue.Contains(task))
                {
                    panel.taskQueue.Remove(task);
                    Debug.Log($"Task failed: {task.taskName}");
                    GameManager.Instance.shipHealth -= task.taskDamage;
                    break;
                }
            }
        }
    }
}