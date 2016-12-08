using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

	public Vector3[] spawnerPoint;
	public float minTime = 1.0f;
	public float maxTime = 2.0f;
	public float speed = 3.0f;
	public GameObject itemPrefab;

	float time = 0;
	float nextSpawnTime = 1.0f;
	Queue queue;

	public Transform player;

	void Start() {
		queue = new Queue ();
	}

	float GetAverage() {
		float avg = -0.85f;
		foreach (var q in queue) {
			avg += (float)q;
		}
		Debug.Log (queue.Count);
		return avg/queue.Count;
	}

	// Update is called once per frame
	void Update () {
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

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;

		foreach (var i in spawnerPoint) {
			Gizmos.DrawCube (i, Vector3.one * 0.25f);
		}

		//Gizmos.DrawLine (new Vector3(spawnerPoint.xMin, spawnerPoint.yMin), new Vector3(spawnerPoint.xMin, spawnerPoint.yMax));
		//Gizmos.DrawLine (new Vector3(spawnerPoint.xMin, spawnerPoint.yMax), new Vector3(spawnerPoint.xMax, spawnerPoint.yMax));
		//Gizmos.DrawLine (new Vector3(spawnerPoint.xMax, spawnerPoint.yMax), new Vector3(spawnerPoint.xMax, spawnerPoint.yMin));
		//Gizmos.DrawLine (new Vector3(spawnerPoint.xMax, spawnerPoint.yMin), new Vector3(spawnerPoint.xMin, spawnerPoint.yMin));
	}
}
