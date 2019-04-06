using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private float offsetX;
    private float leftBoundary;
    private float rightBoundary;
    private readonly float SPEED = 3;
    private bool movingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        offsetX = 3;
        leftBoundary = transform.position.x - offsetX;
        rightBoundary = transform.position.x + offsetX;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (movingLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(leftBoundary, transform.position.y, transform.position.z), Time.deltaTime * SPEED);
            if (transform.position.x <= leftBoundary)
            {
                movingLeft = !movingLeft;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(rightBoundary, transform.position.y, transform.position.z), Time.deltaTime * SPEED);
            if (transform.position.x >= rightBoundary)
            {
                movingLeft = !movingLeft;
            }
        }
    }
}


