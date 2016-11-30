using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public Vector3 direction;

	private Camera mainCamera;
	private int screenWidth;
	private int screenHeight;

	// Use this for initialization
	void Start () {
		
	}

	void Awake () {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawLine (this.transform.position, this.transform.position + direction.normalized*5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}	
}
