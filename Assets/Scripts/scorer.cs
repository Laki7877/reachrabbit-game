using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scorer : MonoBehaviour {

	public Text text;
	public GameObject player;
	public GameObject hill;
	public GameObject mountain;
	public GameObject burgerSpawner;

	float meinScore = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		burgerSpawner.GetComponent<ItemSpawner> ().speed = hill.GetComponent<Parallax> ().speed;
	}
	void FixedUpdate(){

		if (player.GetComponent<PlayerState>().isDead) {
			return;
		}

		meinScore += 0.01f;
		text.text = Mathf.Round (meinScore) + " m";
	}

	public void Die() {
		player.GetComponent<PlayerState> ().isDead = true;
		player.GetComponent<Animator> ().SetTrigger ("Die");

		var o = GameObject.FindGameObjectsWithTag ("Parallax");
		var g = GameObject.FindGameObjectsWithTag ("Item");
		burgerSpawner.GetComponent<ItemSpawner> ().enabled = false;

		player.GetComponent<BoxCollider2D> ().enabled = false;
		player.GetComponent<CircleCollider2D> ().enabled = true;

		player.GetComponent<Rigidbody2D> ().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
		player.GetComponent<Rigidbody2D> ().AddTorque (100.0f);
		// disable all parallax
		foreach (var s in o) { 
			s.GetComponent<Parallax> ().enabled = false;	
		}
		foreach (var s in g) {
			s.GetComponent<Burger> ().enabled = false;
		}
	}
	public void Retry() {
		
	}
}
