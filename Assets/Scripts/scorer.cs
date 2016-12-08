using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scorer : MonoBehaviour {

	public Text text;
	public Vector3 playerSpawnPoint =  new Vector3(0, -0.58f, 0);
	public GameObject playerPrefab;
	public GameObject player;
	public GameObject hill;
	public GameObject mountain;
	public GameObject cloud;
	public GameObject burgerSpawner;

	float meinScore = 0;

	// Use this for initialization
	void Start () {
		meinScore = 0;
		StopGame ();
		updateScoreText ();
	}
	
	// Update is called once per frame
	void Update () {
		burgerSpawner.GetComponent<ItemSpawner> ().speed = hill.GetComponent<Parallax> ().speed;
	}
	void FixedUpdate(){
		if (IsDead()) {
			if (IsTapped () && player == null) {
				StartGame ();
			}
			return;
		}

		meinScore += 0.01f;
		updateScoreText ();
	}

	bool IsTapped() {
		return (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || Input.GetButtonDown ("Jump");
	}

	void updateScoreText() {
		text.text = Mathf.Round (meinScore) + " m";
	}
	public bool IsDead() {
		return (player != null) ? player.GetComponent<PlayerState> ().isDead : true;
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
	public void StartGame() {
		meinScore = 0;
		updateScoreText ();
		player = Instantiate(playerPrefab, this.transform.parent) as GameObject;
		player.transform.position = playerSpawnPoint;
		hill.GetComponent<Parallax> ().enabled = true;
		mountain.GetComponent<Parallax> ().enabled = true;
		cloud.GetComponent<Parallax> ().enabled = true;
		burgerSpawner.GetComponent<ItemSpawner> ().player = player;
		burgerSpawner.GetComponent<ItemSpawner> ().enabled = true;
	}
	public void StopGame() {
		hill.GetComponent<Parallax> ().enabled = false;
		mountain.GetComponent<Parallax> ().enabled = false;
		cloud.GetComponent<Parallax> ().enabled = false;
		burgerSpawner.GetComponent<ItemSpawner> ().enabled = false;
	}
}
