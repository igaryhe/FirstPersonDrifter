// original by asteins
// adapted by @torahhorse
// modified by @igaryhe
// http://wiki.unity3d.com/index.php/SmoothMouseLook

// Instructions:
// There should be one MouseLook script on the Player itself, and another on the camera
// player's MouseLook should use MouseX, camera's MouseLook should use MouseY

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
 
	public enum RotationAxes { MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseX;
	public bool invertY;
	
	public float sensitivity = 10F;

	public float minimumX = -360F;
	public float maximumX = 360F;
 
	public float minimumY = -85F;
	public float maximumY = 85F;
	
	private float rotation;

	private List<float> rotArray = new List<float>();
	private float rotAverage;
 
	public float framesOfSmoothing = 5;
 
	Quaternion originalRotation;

	private float inputX;
	private float inputY;

	private void Start ()
	{			
		if (GetComponent<Rigidbody>()) GetComponent<Rigidbody>().freezeRotation = true;
		originalRotation = transform.localRotation;
	}

	private void Update()
	{
		rotAverage = 0f;
		if (axes == RotationAxes.MouseX) rotation += inputX * sensitivity * Time.timeScale;
		else
		{
			var invertFlag = 1f;
			if (invertY) invertFlag = -1f;
			rotation += inputY * sensitivity * invertFlag * Time.timeScale;
			rotation = Mathf.Clamp(rotation, minimumY, maximumY);
		}
		
		rotArray.Add(rotation);
		if (rotArray.Count >= framesOfSmoothing) rotArray.RemoveAt(0);
		foreach (var t in rotArray) rotAverage += t;
		rotAverage /= rotArray.Count;
		
		if (axes == RotationAxes.MouseX)
		{
			rotAverage = ClampAngle(rotAverage, minimumX, maximumX);
			transform.localRotation = originalRotation * Quaternion.AngleAxis (rotAverage, Vector3.up);			
		}
		else transform.localRotation = originalRotation * Quaternion.AngleAxis (rotAverage, Vector3.left);
	}

	private static float ClampAngle (float angle, float min, float max)
	{
		angle %= 360;
		if (!(angle >= -360F) || !(angle <= 360F)) return Mathf.Clamp(angle, min, max);
		if (angle < -360F) angle += 360F;
		if (angle > 360F) angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}

	public void Look(InputAction.CallbackContext ctx)
	{
		inputX = ctx.ReadValue<Vector2>().x * 0.01f;
		inputY = ctx.ReadValue<Vector2>().y * 0.01f;
	}
}