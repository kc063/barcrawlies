using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetListener : MonoBehaviour
{
    [SerializeField] private Transform spawner; 
    private void OnEnable()
    {
        ResetManager.OnGameReset += ResetActions; // Subscribe to the reset event
    }

    private void OnDisable()
    {
        ResetManager.OnGameReset -= ResetActions; // Unsubscribe when disabled
    }

    private void ResetActions()
    {
        gameObject.GetComponent<CharacterControl>().Refresh();
        transform.position = spawner.position; 
    }
}
