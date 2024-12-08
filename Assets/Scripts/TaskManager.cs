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
    
    public GameObject taskCompletePrefab;
    public GameObject taskFailPrefab;

    public AudioSource taskSoundSource;
    public AudioClip taskSuccess;
    public AudioClip taskFail;


    // Dictionary to track the prefab instance for each task
    private Dictionary<Task, GameObject> taskPrefabMap = new Dictionary<Task, GameObject>();

    // Set to track tasks that are already on the board
    private HashSet<Task> tasksOnBoard = new HashSet<Task>();

    private void Awake()
    {
        Instance = this;
    }

    public void AssignTask(int panelIndex, int taskIndex)
    {
        Task task = tasks[taskIndex];
        PanelManager panel = panels[panelIndex];

        // Check if the task is already on the board
        if (tasksOnBoard.Contains(task))
        {
            Debug.Log($"Task {task.taskName} is already on the board and cannot be assigned again.");
            return; // Skip task assignment if it is already on the board
        }

        // Add the task to the queue
        panel.taskQueue.Add(task);

        // Instantiate a unique prefab
        GameObject taskObject = Instantiate(taskPrefab, panel.taskQueuePanel.transform, false);

        // Assign the correct task name to the prefab's text
        TaskContainer taskContainer = taskObject.GetComponent<TaskContainer>();
        taskContainer.SetTask(task, task.taskDescription, task.taskTime, task.taskDamage);

        // Map the task to its prefab instance
        taskPrefabMap[task] = taskObject;

        // Mark the task as being on the board
        tasksOnBoard.Add(task);

        Debug.Log($"Assigned task {task.taskName} to panel {panel.gameObject.name}");
    }


    public void CompleteTaskPrefab(Task task)
    {
        if (taskPrefabMap.TryGetValue(task, out GameObject taskObject))
        {
            Instantiate(taskCompletePrefab, taskObject.transform.position, taskObject.transform.rotation);
            taskSoundSource.clip = taskSuccess;
            GameManager.Instance.score += 100f;
            taskSoundSource.Play();
            Destroy(taskObject); // Remove the prefab
            taskPrefabMap.Remove(task); // Clean up the dictionary

            // Remove the task from the set of tasks on the board
            tasksOnBoard.Remove(task);
        }
    }

    public void FailTaskPrefab(Task task)
    {
        if (taskPrefabMap.TryGetValue(task, out GameObject taskObject))
        {
            Instantiate(taskFailPrefab, taskObject.transform.position, taskObject.transform.rotation);
            taskSoundSource.clip = taskFail;
            taskSoundSource.Play();
            Destroy(taskObject); // Remove the task's GameObject
            taskPrefabMap.Remove(task); // Clean up the dictionary

            // Remove the task from the set of tasks on the board
            tasksOnBoard.Remove(task);

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
