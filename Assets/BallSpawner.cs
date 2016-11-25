using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

	[SerializeField] private GameObject Ammo;
	public float ShootSpeed;

	void SpawnBall(){
		GameObject ball = (GameObject)Instantiate (Ammo, transform.position, Quaternion.identity);
		ball.GetComponent<Rigidbody2D> ().AddForce (Vector2.one * 1);
	}
}
