using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int orbCount = 0;
    public int orbsToUnlockGravity = 2;
    public bool gravityUnlocked = false;
    public bool hasKey = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddOrb()
    {
        orbCount++;
        Debug.Log("Orb Count: " + orbCount);

        if (orbCount >= orbsToUnlockGravity)
        {
            gravityUnlocked = true;
            Debug.Log("Gravity flip unlocked!");
        }
    }


    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("Key collected!");
    }
}