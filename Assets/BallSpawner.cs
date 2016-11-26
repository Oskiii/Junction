using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

	[SerializeField] private GameObject Ammo;
	public float ShootSpeed;
	public float SpawnDelay;
	private float lastSpawn;

	void SpawnBall(){
		GameObject ball = (GameObject)Instantiate (Ammo, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	void Update(){
		if((Time.time - lastSpawn) > SpawnDelay){
			SpawnBall ();
			lastSpawn = Time.time;
		}

	}
}
