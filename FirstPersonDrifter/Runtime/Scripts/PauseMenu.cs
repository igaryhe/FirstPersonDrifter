using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    
    private static bool _gameIsPaused;

    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
        LockCursor(true);
        AudioListener.pause = false;
    }

    private void Pause()
    {
        if (!_gameIsPaused)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            _gameIsPaused = true;
            LockCursor(false);
            AudioListener.pause = true;
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
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
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

    private void LockCursor(bool lockCursor)
    {
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }
}