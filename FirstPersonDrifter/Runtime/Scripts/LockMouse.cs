// by @torahhorse
// modified by @igaryhe

using UnityEngine;

public class LockMouse : MonoBehaviour
{
	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}