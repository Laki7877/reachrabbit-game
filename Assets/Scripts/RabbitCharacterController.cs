using UnityEngine;
using System.Collections;

public class RabbitCharacterController : MonoBehaviour {
	public float jumpingForce = 250.0f;
	public AudioClip jumpSound;
	public AudioClip hitSound;
	private Rigidbody2D body;
	private Animator animator;

	// Use this for initialization
	void Awake () {
		body = this.GetComponent<Rigidbody2D> ();
		animator = this.GetComponent<Animator>();
	}
	void Start() {
	}

	void OnCollisionEnter2D(Collision2D o) {
		if (o.collider.tag == "Hill") {
			if (GetComponent<PlayerState> ().isRun) {
				animator.SetBool ("IsRun", true);
			}
			animator.SetBool ("IsJump", false);
			animator.SetBool ("IsGrounded", true);
		}
	}
	public void Die() {
		GameObject.FindGameObjectWithTag ("GameManager").GetComponent<scorer> ().Die ();
		GetComponent<AudioSource> ().PlayOneShot (hitSound);
	}

	public void Jump() {
		animator.SetBool ("IsGrounded", false);
		animator.SetBool ("IsJump", true);
		body.AddForce(new Vector2(0f, jumpingForce));
		GetComponent<AudioSource> ().PlayOneShot (jumpSound);
	}
}
