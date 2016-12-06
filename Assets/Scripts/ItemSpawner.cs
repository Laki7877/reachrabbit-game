using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

	public Vector3[] spawnerPoint;
	public float minTime = 1.0f;
	public float maxTime = 2.0f;
	public GameObject itemPrefab;

	float time = 0;
	float nextSpawnTime = 1.0f;

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time >= nextSpawnTime) {
			time = 0.0f;
			nextSpawnTime = Random.Range(minTime, maxTime);
		
			var point = Random.Range (0, spawnerPoint.Length);

			// spawn item
			Instantiate(itemPrefab, spawnerPoint[point], Quaternion.Euler(0,0,7.5f), this.transform);
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
