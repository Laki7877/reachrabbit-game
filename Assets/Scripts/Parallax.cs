using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	private Camera mainCamera;
	private int screenWidth;
	private int screenHeight;

	// Use this for initialization
	void Start () {
	}

	void Awake () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
