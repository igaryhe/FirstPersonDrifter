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

	public static void LockCursor(bool lockCursor)
    {
	    Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }
}