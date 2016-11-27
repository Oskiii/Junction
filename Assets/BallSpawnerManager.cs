using UnityEngine;
using System.Collections;

public class BallSpawnerManager : MonoBehaviour {

	[SerializeField] private float spawnDelay;
	public bool ShouldSpawn;
	public GameObject SpawnerObject;
	private float lastSpawn;

	private Vector2 topLeft;
	private Vector2 bottomRight;

	void Start(){
		topLeft = Camera.main.ScreenToWorldPoint (new Vector3(0, 0, 0));
		bottomRight = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0));
	}

	void Update(){
		if (ShouldSpawn) {

			if((Time.time - lastSpawn) > spawnDelay){
				SpawnSpawner ();
				lastSpawn = Time.time;
			}

			spawnDelay *= 0.9999f; 
		}

	}

	void SpawnSpawner(){
		Instantiate (SpawnerObject, GetRandomLocation(), Quaternion.identity);
	}

	Vector2 GetRandomLocation(){
		int side = Random.Range (0, 3);
		float x = 0;
		float y = 0;

		//0 = top, 1 = right, 2 = bottom, 3 = left
		switch (side) {
		case 0:
			x = Random.Range (topLeft.x, bottomRight.x);
			y = topLeft.y;
			break;
		case 1:
			x = bottomRight.x;
			y = Random.Range (topLeft.y, bottomRight.y);
			break;
		case 2:
			x = Random.Range (topLeft.x, bottomRight.x);
			y = bottomRight.y;
			break;
		case 3:
			x = topLeft.x;
			y = Random.Range (topLeft.y, bottomRight.y);
			break;
		}

		return new Vector2 (x, y);
	}
}
