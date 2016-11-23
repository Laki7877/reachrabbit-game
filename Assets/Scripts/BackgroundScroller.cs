using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour
{
	
    public float scrollSpeed;
    public float tileSizeX;

    private Vector3 startPosition;
    // Use this for initialization
    void Start()
    {
        startPosition = this.transform.position;
    }
	
    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX * this.transform.localScale.x);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
