using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

	public float minTime = 1.0f;
	public float maxTime = 2.0f;
	public float speed = 3.0f;
	public GameObject itemPrefab;
	public GameObject player;

	float time = 0;
	float nextSpawnTime = 1.0f;

	Queue queue;

	void Start() {
		queue = new Queue ();
	}

	float GetAverage() {
		float avg = -0.85f;
		foreach (var q in queue) {
			avg += (float)q;
		}
		return avg/queue.Count;
	}

	// Update is called once per frame
	void Update () {
		if (player == null) {
			return;
		}

		time += Time.deltaTime;
		queue.Enqueue (player.transform.position.y);

		if (time >= nextSpawnTime) {
			time = 0.0f;
			nextSpawnTime = Random.Range(minTime, maxTime);

			// spawn item
			var burger = Instantiate(itemPrefab, new Vector3(4.74f, GetAverage(), 0), Quaternion.Euler(0,0,7.5f), this.transform) as GameObject;

			burger.GetComponent<Burger> ().speed = this.speed;
		}

		if (queue.Count > 10) {
			queue.Dequeue ();
		}
	}
}
