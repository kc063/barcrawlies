using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public static event System.Action OnGameReset;
    [SerializeField] private GameObject pause;

    public void TriggerReset()
    {
        OnGameReset?.Invoke();
        pause.GetComponent<PauseControl>().PauseGame();
    }
}