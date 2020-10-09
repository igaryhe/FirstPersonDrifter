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
	
	public float sensitivityX = 10F;
	public float sensitivityY = 9F;
 
	public float minimumX = -360F;
	public float maximumX = 360F;
 
	public float minimumY = -85F;
	public float maximumY = 85F;
 
	float rotationX;
	float rotationY;
 
	private List<float> rotArrayX = new List<float>();
	float rotAverageX;	
 
	private List<float> rotArrayY = new List<float>();
	float rotAverageY;
 
	public float framesOfSmoothing = 5;
 
	Quaternion originalRotation;

	private float inputX;
	private float inputY;

	private void Start ()
	{			
		if (GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		
		originalRotation = transform.localRotation;
	}

	private void Update ()
	{
		if (axes == RotationAxes.MouseX)
		{			
			rotAverageX = 0f;

			rotationX += inputX * sensitivityX * Time.timeScale;

			rotArrayX.Add(rotationX);
 
			if (rotArrayX.Count >= framesOfSmoothing)
			{
				rotArrayX.RemoveAt(0);
			}
			foreach (var t in rotArrayX)
			{
				rotAverageX += t;
			}
			rotAverageX /= rotArrayX.Count;
			rotAverageX = ClampAngle(rotAverageX, minimumX, maximumX);
			
			transform.localRotation = originalRotation * Quaternion.AngleAxis (rotAverageX, Vector3.up);			
		}
		else
		{			
			rotAverageY = 0f;
 
 			var invertFlag = 1f;
 			if( invertY )
 			{
 				invertFlag = -1f;
 			}

			rotationY += inputY * sensitivityY * invertFlag * Time.timeScale;
			
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
 	
			rotArrayY.Add(rotationY);
 
			if (rotArrayY.Count >= framesOfSmoothing)
			{
				rotArrayY.RemoveAt(0);
			}
			foreach (var t in rotArrayY)
			{
				rotAverageY += t;
			}
			rotAverageY /= rotArrayY.Count;
			
			transform.localRotation = originalRotation * Quaternion.AngleAxis (rotAverageY, Vector3.left);
		}
	}
	
	public void SetSensitivity(float s)
	{
		sensitivityX = s;
		sensitivityY = s;
	}

	private static float ClampAngle (float angle, float min, float max)
	{
		angle %= 360;
		if (!(angle >= -360F) || !(angle <= 360F)) return Mathf.Clamp(angle, min, max);
		if (angle < -360F) {
			angle += 360F;
		}
		if (angle > 360F) {
			angle -= 360F;
		}
		return Mathf.Clamp (angle, min, max);
	}

	public void Look(InputAction.CallbackContext ctx)
	{
		inputX = ctx.ReadValue<Vector2>().x * 0.01f;
		inputY = ctx.ReadValue<Vector2>().y * 0.01f;
	}
}