﻿using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag.Equals ("Player")) {
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<scorer> ().StopGame ();
			StartCoroutine (Wait(other.gameObject));
		}
	}

	IEnumerator Wait(GameObject o) {
		yield return new WaitForSeconds (1);
		o.SetActive (false);
		Destroy (o.gameObject);
	}
}
