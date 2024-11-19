using UnityEngine;


[CreateAssetMenu(fileName = "Task", menuName = "Task", order = 0)]
public class Task : ScriptableObject
{
    public string taskName;
    public string taskDescription;
    public string taskCompleteCondition;

}
