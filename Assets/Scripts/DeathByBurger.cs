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
		if (collider.tag == "Item") {
			//dead
			collider.gameObject.SetActive (false);
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<scorer> ().Die ();
		}
	}
}