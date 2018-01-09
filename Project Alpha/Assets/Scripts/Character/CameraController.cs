using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform target;

	public Vector3 offset;
	public float zoomSpeed = 4f;
	public float minZoom = 5f;
	public float maxZoom = 10f;

	public float pitch = 2f;
	public float yawSpeed = 100f;

	public float currentZoom = 5f;
	private float currentYaw = 0f;

	Vector3 forward;

	void Start(){
		Time.timeScale = 1;
	}
	void Update(){
		//zoom in/out
		currentZoom -= Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp (currentZoom,minZoom,maxZoom);

		//move camera with a/d 
		currentYaw += Input.GetAxis("Horizontal")*yawSpeed*Time.deltaTime;
	}

	void LateUpdate(){
		FocusPlayer ();
		//look around 
		if(Input.GetButton("Horizontal")){
			transform.RotateAround (target.position, Vector3.up, currentYaw);
		}
		if(Input.GetButtonUp("Horizontal")){
			currentYaw = 0f;
		}
	}

	void FocusPlayer(){
		//camera always keep the player in the middle
		transform.position = target.position - offset * currentZoom;
		transform.LookAt (target.position + Vector3.up * pitch);
		//keep camera always look at the player's back
		forward = target.transform.forward;
		forward.y = 0;
		transform.RotateAround (target.position, Vector3.up, Quaternion.LookRotation(forward).eulerAngles.y);
	}
}
