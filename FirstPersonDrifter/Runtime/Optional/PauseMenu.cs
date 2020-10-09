using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;

    public GameObject PauseMenuUI;

    public GameObject OptionsMenuUI;

    private void Resume()
    {
        Debug.Log("Resumed");
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        LockMouse.LockCursor(true);
    }

    private void Pause()
    {
        if (!GameIsPaused)
        {
            Debug.Log("Paused");
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            LockMouse.LockCursor(false);
        } else Resume();
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.started) Pause();
    }

    public void OnResume()
    {
        Resume();
    }

    public void OnOptionsMenu()
    {
        OptionsMenuUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnReset()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}