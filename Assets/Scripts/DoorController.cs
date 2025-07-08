using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorController : MonoBehaviour
{
    public int requiredOrbs = 2; 

    void Update()
    {
        if (GameManager.Instance.orbCount >= requiredOrbs)
        {
            gameObject.SetActive(false);
        }
    }
}
