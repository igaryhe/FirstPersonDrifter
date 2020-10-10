// by @torahhorse
// modified by @igaryhe

using UnityEngine;
using UnityEngine.InputSystem;

// allows player to zoom in the FOV when holding a button down
[RequireComponent (typeof (Camera))]
public class CameraZoom : MonoBehaviour
{
	public float zoomFOV = 30.0f;
	public float zoomSpeed = 9f;
	
	private float targetFOV;
	private float baseFOV;

	private bool zoom;
	private Camera camera;

	private void Start ()
	{
		camera = Camera.main;
		baseFOV = camera.fieldOfView;
	}

	private void Update ()
	{
		targetFOV = zoom ? zoomFOV : baseFOV;
		UpdateZoom();
	}
	
	private void UpdateZoom()
	{
		camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
	}

	public void OnZoom(InputAction.CallbackContext ctx)
	{
		zoom = ctx.performed;
	}
}
