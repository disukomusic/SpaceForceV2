using UnityEngine;
using TMPro;


public class TaskContainer : MonoBehaviour
{
    public TMP_Text taskNameText;

    public void SetTask(string taskName)
    {
        taskNameText.text = taskName;
    }
}

