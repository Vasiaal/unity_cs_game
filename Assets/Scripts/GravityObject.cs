using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    public float floatHeight = 2f;
    public float floatDuration = 1f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool isFloating = false;
    private float timer = 0f;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.up * floatHeight;
    }

    public void StartFloating()
    {
        isFloating = true;
        timer = 0f;
    }

    void Update()
    {
        if (isFloating)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / floatDuration);
            transform.position = Vector3.Lerp(startPos, endPos, t);

            if (t >= 1f)
            {
                isFloating = false;
            }
        }
    }
}
