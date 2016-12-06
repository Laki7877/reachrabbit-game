using UnityEngine;
using System.Collections;

public class ItemDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag.Equals ("Item")) {
			other.gameObject.SetActive (false);
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Destroy (other.gameObject);
		}
	}
}
