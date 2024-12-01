// using System;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
//
// public class TaskUI : MonoBehaviour
// {
//     private PanelManager _panelManager;
//     private TMP_Text _taskQueueText;
//
//     private void Awake()
//     {
//         _panelManager = GetComponentInParent<PanelManager>();
//         _taskQueueText = GetComponent<TMP_Text>();
//     }
//
//     private void Update()
//     {
//         _taskQueueText.text = FormatTaskQueue();
//     }
//
//     //todo: everything is currently formatted into a string. it should be separate TMP objects in the scene.
//     string FormatTaskQueue()
//     {
//         // Create a list to hold formatted descriptions
//         List<string> taskDescriptions = new List<string>();
//
//         // Loop through the taskQueue and format descriptions
//         foreach (Task task in _panelManager.taskQueue)
//         {
//             taskDescriptions.Add($"- {task.taskDescription}");
//         }
//
//         // Join the descriptions into a single string separated by line breaks
//         return string.Join("\n", taskDescriptions);
//     }
// }