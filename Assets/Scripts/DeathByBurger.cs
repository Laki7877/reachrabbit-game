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
			this.GetComponent<Animator> ().SetTrigger ("Die");
		}
	}
}