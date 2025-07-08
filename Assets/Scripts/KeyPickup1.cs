using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyPickup1 : MonoBehaviour
{
    public TextMeshProUGUI keyMessageText; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectKey();
            keyMessageText.text = "Congratulations! You found the key!";
            Destroy(gameObject);
        }
    }
}

