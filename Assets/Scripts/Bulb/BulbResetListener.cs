using UnityEngine;

public class BulbResetListener : MonoBehaviour
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
        BulbData b = GetComponent<BulbData>();

        if (b != null)
        {
            // You have the Rigidbody component, you can now use it
            b.Refresh();
        }
        else
        {
            Debug.LogWarning("Bulb was not able to refresh.");
        }
    }
}