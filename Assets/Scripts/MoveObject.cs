using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 2f;          // Speed of movement
    public float distance = 2f;      // Maximum movement distance

    private Vector3 startPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        if (movingUp)
        {
            transform.position += new Vector3(0, movement, 0);
            if (transform.position.y >= startPos.y + distance)
                movingUp = false;
        }
        else
        {
            transform.position -= new Vector3(0, movement, 0);
            if (transform.position.y <= startPos.y - distance)
                movingUp = true;
        }
    }
}

