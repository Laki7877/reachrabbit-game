using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public float speed;
	public float tileSizeX;
	public float debugSpeed;
	public Vector3 direction;
	private Vector3 startPosition;
	private Camera mainCamera;
	private int screenWidth;
	private int screenHeight;

	// Use this for initialization
	void Start () {
		startPosition = this.transform.position;
	}

	void Awake () {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawLine (this.transform.position, this.transform.position + direction.normalized*2);
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(Time.time * speed, tileSizeX);
		debugSpeed = newPosition;
		transform.position = startPosition + direction.normalized * debugSpeed;
	}	
}
