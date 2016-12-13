using UnityEngine;
using System.Collections;

public class RabbitUserControl : MonoBehaviour {
	public float jumpingTimeout = 0.1f;

	RabbitCharacterController controller;
	float _jumpingTimeout = 0.0f;

	// Use this for initialization
	void Awake () {
		controller = this.GetComponent<RabbitCharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (this.GetComponent<PlayerState> ().isDead) {
			return;
		}
		_jumpingTimeout += Time.deltaTime;	
	}

	bool IsTapped() {
		return (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || Input.GetButtonDown ("Jump");
	}

	public void Touch() {
		if (_jumpingTimeout >= jumpingTimeout) {
				controller.Jump ();	
				_jumpingTimeout = 0;
			}
	}
}
