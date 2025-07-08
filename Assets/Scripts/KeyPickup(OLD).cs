using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public FinalDoor finalDoor; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectKey();

            if (finalDoor != null)
            {
                finalDoor.OpenDoor();
            }

            Destroy(gameObject);
        }
    }
}