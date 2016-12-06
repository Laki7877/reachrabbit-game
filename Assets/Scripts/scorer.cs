using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scorer : MonoBehaviour {

	public Text text;
	float meinScore = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		meinScore += 0.01f;
		text.text = Mathf.Round (meinScore) + " m";
	}
}
