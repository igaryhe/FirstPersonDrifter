// by @torahhorse
// modified by @igaryhe

using UnityEngine;
using UnityEngine.InputSystem;

public class LockMouse : MonoBehaviour
{
	private bool pause;
	private void Start()
	{
		LockCursor(true);
	}

	private void Update()
    {
    	// lock when mouse is clicked
    	if( Time.timeScale > 0.0f )
    	{
    		LockCursor(true);
    	}
    }

    private static void LockCursor(bool lockCursor)
    {
	    Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
	    if (ctx.started) LockCursor(false);
    }
}