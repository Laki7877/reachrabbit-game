using UnityEngine;
using System.Collections;

public class RabbitCharacterController : MonoBehaviour {
	public float jumpingForce = 250.0f;
	private Rigidbody2D body;
	private Animator animator;

	// Use this for initialization
	void Awake () {
		body = this.GetComponent<Rigidbody2D> ();
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D o) {
		if (o.collider.tag == "Hill") {
			animator.SetBool ("IsRun", true);
			animator.SetBool ("IsGrounded", true);
		}
	}

	public void Jump() {
		animator.SetBool ("IsGrounded", false);
		body.AddForce(new Vector2(0f, jumpingForce));
	}
}
