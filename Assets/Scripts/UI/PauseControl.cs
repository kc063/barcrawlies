using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    [SerializeField] private GameObject talkObject;
    private int score;
    public TMP_Text count;
    private bool tlk = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
            gameIsPaused = !gameIsPaused;
        }
    }
    public void PauseGame()
    {
        score = 0;
        if (talkObject.activeInHierarchy)
        {
            tlk = true;
        }
        if (!gameIsPaused)
        {
            if (tlk)
            {
                talkObject.SetActive(false);
            }
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            ShowOnMenu[] componentsInChildren = pauseMenu.GetComponentsInChildren<ShowOnMenu>();

            foreach (ShowOnMenu component in componentsInChildren)
            {
                if (!component.show)
                {
                    component.gameObject.SetActive(false);
                }
                else
                {
                    score += 1;
                }
                Debug.Log(score);
                count.text = score.ToString() + "/40";
            }
            

        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            if (tlk)
            {
                talkObject.SetActive(true);
                tlk = false;
            }
        }
    }
}