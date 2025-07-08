using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public float liftHeight = 5f;
    public float liftSpeed = 2f;
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool openDoor = false;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(0, liftHeight, 0);
    }

    void Update()
    {
        if (openDoor)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, liftSpeed * Time.deltaTime);
        }
    }

    public void OpenDoor()
    {
        openDoor = true;
    }
}
