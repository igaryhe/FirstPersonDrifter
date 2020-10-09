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
	
	void Start ()
	{
		SetBaseFOV(GetComponent<Camera>().fieldOfView);
	}
	
	void Update ()
	{
		targetFOV = zoom ? zoomFOV : baseFOV;

		UpdateZoom();
	}
	
	private void UpdateZoom()
	{
		GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
	}
	
	public void SetBaseFOV(float fov)
	{
		baseFOV = fov;
	}

	public void OnZoom(InputAction.CallbackContext ctx)
	{
		zoom = ctx.performed;
	}
}
