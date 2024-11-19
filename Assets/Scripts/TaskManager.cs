using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    
    public PanelManager[] panels;
    public Task[] tasks;

    private void Awake()
    {
        Instance = this;
    }

    public void AssignTask(int panelIndex, int taskIndex)
    {
        panels[panelIndex].taskQueue.Add(tasks[taskIndex]);
        Debug.Log($"assigned task {tasks[taskIndex].taskName} to panel {panels[panelIndex].gameObject.name}" );
    }
}
