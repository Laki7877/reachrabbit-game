using UnityEngine;
using System.Collections;

public class Burger : MonoBehaviour {

	public Vector3 direction = new Vector3(-1.00f,-0.12f,0.00f);
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += direction.normalized * speed * Time.deltaTime;

//		float delta_y = 3*Mathf.Cos (Time.realtimeSinceStartup * 180 / Mathf.PI )*Time.deltaTime;
//		Vector3 yo = this.transform.position;
//		yo.y -= delta_y;
//		this.transform.position = yo;
	}
}
