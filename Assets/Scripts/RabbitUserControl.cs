using UnityEngine;
using System.Collections;

public class RabbitUserControl : MonoBehaviour {

	RabbitCharacterController controller;
	// Use this for initialization
	void Awake () {
		controller = this.GetComponent<RabbitCharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		
		if ((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) ||  Input.GetButtonDown("Jump")) {
			controller.Jump ();
		}	
	}
}
