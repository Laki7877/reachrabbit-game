using UnityEngine;
using System.Collections;

public class RabbitCollider : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Awake () {
		animator = this.transform.parent.GetComponent<Animator> ();
	}


	void OnCollisionEnter2D(Collision2D o) {
		if (o.collider.tag == "Hill") {
			animator.SetBool ("IsRun", true);
			animator.SetBool ("IsJump", false);
			animator.SetBool ("IsGrounded", true);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
