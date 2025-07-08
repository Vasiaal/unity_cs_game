using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 startPoint;
    private Vector3 endPoint;

    public float moveDistance = 5f; 
    public float speed = 2f;         
    private bool movingForward = true;

    void Start()
    {
        startPoint = transform.position;
        endPoint = startPoint + new Vector3(moveDistance, 0f, 0f); 
    }

    void Update()
    {
        Vector3 target = movingForward ? endPoint : startPoint;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
            movingForward = !movingForward;
    }
}


