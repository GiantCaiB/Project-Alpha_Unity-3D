using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	public LayerMask movementMask;

	Camera cam;
	PlayerMotor motor;
	public Transform canvas;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		motor = GetComponent<PlayerMotor> ();
	}
	
	// Update is called once per frame
	void Update () {
		//left mouse button
		if(Input.GetMouseButtonDown(0)){
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			//if not paused
			if(canvas.gameObject.activeInHierarchy==false){
				if(Physics.Raycast(ray, out hit, 100, movementMask)){
					motor.MoveToPoint (hit.point);
					//Debug.Log(hit.collider.name+" : "+hit.point);
				}
			}
		}
	}
		
}
