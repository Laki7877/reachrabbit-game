using UnityEngine;
using System.Collections;

public class DeathByBurger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log (collider.tag);
		if (collider.tag == "Item") {
			//dead
			Debug.Log("DEAD");
			this.GetComponent<PlayerState> ().isDead = true;
			this.GetComponent<Animator> ().SetTrigger ("Die");
			var o = GameObject.FindGameObjectsWithTag ("Parallax");
			var g = GameObject.FindGameObjectsWithTag ("Item");
			var spw = GameObject.FindGameObjectWithTag ("ItemLayer");
			spw.GetComponent<ItemSpawner> ().enabled = false;
			foreach (var s in o) { 
				s.GetComponent<Parallax> ().enabled = false;	
			}

			foreach (var s in g) {
				s.GetComponent<Burger> ().enabled = false;
			}
			collider.gameObject.SetActive (false);

			this.GetComponent<Rigidbody2D> ().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
			this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-350f, 0));
		}
	}
}