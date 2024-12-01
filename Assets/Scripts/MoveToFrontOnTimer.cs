using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveToFrontOnTimer : MonoBehaviour
{
    public float delay = 2f;   // Delay in seconds before moving to the front
    public float newZPosition = -1f; // Z position to bring the object forward

    void Start()
    {
        StartCoroutine(MoveToFrontAfterDelay());
    }

    System.Collections.IEnumerator MoveToFrontAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        Vector3 position = transform.position;
        position.z = newZPosition; // Adjust the Z position to bring it forward
        transform.position = position;
    }
}

