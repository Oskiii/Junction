using UnityEngine;
using System.Collections;

public class BallSpawnerManager : MonoBehaviour {

	[SerializeField] private float spawnDelay;
	public bool ShouldSpawn;
	public GameObject SpawnerObject;
	private float lastSpawn;

	void Update(){
		if (ShouldSpawn) {

			float screenMaxX = Camera.current.ScreenToWorldPoint (new Vector3(Screen.width, 0, 0)).x;
			float screenMaxY = Camera.current.ScreenToWorldPoint (new Vector3(Screen.height, 0, 0)).y;

			if((Time.time - lastSpawn) > spawnDelay){
				SpawnSpawner ();
				lastSpawn = Time.time;
			}
		}

	}

	void SpawnSpawner(){
		Instantiate (SpawnerObject);
	}

	void GetRandomSide(){


	}
}
