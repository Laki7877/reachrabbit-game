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
	public GameObject startText;
	public GameObject tryAgainText;

	public float speed = 1.0f;

	int state = 0;
	float meinScore = 0;

	// Use this for initialization
	void Start () {
		meinScore = 0;
		StopGame ();
		StopBg ();
		updateScoreText ();
		PreStartGame ();
	}
	
	// Update is called once per frame
	void Update () {
		burgerSpawner.GetComponent<ItemSpawner> ().speed = hill.GetComponent<Parallax> ().speed;
	}
	void FixedUpdate(){
		if (IsTapped () && state == 0) {
			PreStartGame ();
		}
		else if (IsTapped () && state == 1) {
			StartGame ();
		}
		else if (state == 2) {
			meinScore += 0.01f * speed;
			speed = 1.0f + meinScore / 100.0f;
			GetSpeedFromLevel ();
			updateScoreText ();
		}
	}

	bool IsTapped() {
		return (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) || Input.GetButtonDown ("Jump");
	}

	float GetSpeedFromLevel() {
		hill.GetComponent<Parallax> ().speed = 3.0f * speed;
		mountain.GetComponent<Parallax> ().speed = 0.5f * speed;
		return meinScore;
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
		player.GetComponent<Rigidbody2D> ().constraints &= ~RigidbodyConstraints2D.FreezeRotation;
		player.GetComponent<Rigidbody2D> ().AddTorque (150.0f);
		// disable all parallax
		foreach (var s in o) { 
			s.GetComponent<Parallax> ().enabled = false;	
		}
		foreach (var s in g) {
			s.GetComponent<Burger> ().enabled = false;
		}
	}
	public void StartGame() {
		startText.SetActive (false);
		hill.GetComponent<Parallax> ().enabled = true;
		mountain.GetComponent<Parallax> ().enabled = true;
		cloud.GetComponent<Parallax> ().enabled = true;
		burgerSpawner.GetComponent<ItemSpawner> ().player = player;
		burgerSpawner.GetComponent<ItemSpawner> ().enabled = true;
		player.GetComponent<PlayerState> ().isRun = true;
		state = 2;
	}
	public void PreStartGame() {
		startText.SetActive (true);
		tryAgainText.SetActive (false);
		meinScore = 0;
		updateScoreText ();
		player = Instantiate(playerPrefab, this.transform.parent) as GameObject;
		player.transform.position = playerSpawnPoint;
		state = 1;
	}
	public void StopGame() {
		tryAgainText.SetActive (true);
		var g = GameObject.FindGameObjectsWithTag ("Item");
		foreach (var s in g) {
			s.SetActive (false);
			Destroy (s.gameObject);
		}
		state = 0;
	}

	public void StopBg() {
		var o = GameObject.FindGameObjectsWithTag ("Parallax");
		foreach (var s in o) { 
			s.GetComponent<Parallax> ().enabled = false;	
		}
	}
}
