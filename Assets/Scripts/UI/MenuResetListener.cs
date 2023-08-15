using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuResetListener : MonoBehaviour
{
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
        ShowOnMenu show = GetComponent<ShowOnMenu>();

        if (show != null)
        {
            // You have the Rigidbody component, you can now use it
            show.setShow(false);
        }
        else
        {
            Debug.LogWarning("Menu component not reset.");
        }
    }
}
