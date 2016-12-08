using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BouncyText : MonoBehaviour {

	public float timePeriod;
	public float size;
	float time;

	// Use this for initialization
	void Start () {
		time = 0.0f;
	}

	void Awake() {
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale = Vector3.one + new Vector3(size * Mathf.Sin (time * timePeriod),size * Mathf.Sin (time * timePeriod) ,0);
		time += Time.deltaTime;
	}
}
