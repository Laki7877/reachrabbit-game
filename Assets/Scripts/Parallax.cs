using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public float speed;
	public float tileSizeX;
	public float debugSpeed;
	public Vector3 direction;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = this.transform.position;
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (this.transform.position, this.transform.position + direction.normalized * 2);
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(Time.time * speed, tileSizeX);
		transform.position = startPosition + direction.normalized * newPosition;
	}	
}
