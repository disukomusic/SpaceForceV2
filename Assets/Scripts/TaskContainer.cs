using UnityEngine;
using TMPro;

public class TaskContainer : MonoBehaviour
{
    public TMP_Text taskNameText;
    public float taskDamageValue;
    public float taskDurationValue;
    public RectTransform taskTimerIcon;
    public float t;
    public Task associatedTask;

    public void SetTask(Task task, string taskName, float taskDuration, float taskDamage)
    {
        associatedTask = task;
        taskNameText.text = taskName;
        taskDamageValue = taskDamage;
        taskDurationValue = taskDuration;
        t = 0;
    }

    private void Update()
    {
        t += Time.deltaTime;
        
        // Calculate the new width based on time elapsed
        float newWidth = Mathf.Lerp(127, 0, t / taskDurationValue);
        
        // Apply the new width to the taskTimerIcon
        var sizeDelta = taskTimerIcon.sizeDelta;
        sizeDelta.x = newWidth;
        taskTimerIcon.sizeDelta = sizeDelta;

        if (t >= taskDurationValue)
        {
            Destroy(gameObject);
            // Notify TaskManager about the task failure and clean up.
            TaskManager.Instance.HandleTaskFailure(associatedTask);
        }
    }
}