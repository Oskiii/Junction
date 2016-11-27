using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public float horizontalMoveFactor = 0.5f;
	public float verticalMoveFactor = 0.25f;

	float shake = 0f;
	float duration;
	[SerializeField] float shakeAmount = 0.7f;
	float decreaseFactor = 1.0f;
	Vector3 startingCameraPos;
	public static CameraShake Instance;
	[SerializeField] private AnimationCurve shakeIntensity;




	void Awake(){
		Instance = this;
	}

	void Start(){
		startingCameraPos = Camera.main.transform.position;
	}

	void Update()
	{
		Vector3 playerPos = new Vector3(0, 0, Camera.main.transform.position.z);
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

		foreach (GameObject player in players){
			playerPos += player.transform.position;
		}
		if (players.Length != 0) {
			playerPos /= players.Length;
		} else {
			playerPos = new Vector3(0, 0, Camera.main.transform.position.z);
		}

		Vector3 newpos = new Vector3(playerPos.x * horizontalMoveFactor, playerPos.y * verticalMoveFactor, -10);

		startingCameraPos = newpos;
		//print (newpos);
	
		if (shake > 0) {
			Vector3 randDir = Random.insideUnitSphere;
			randDir = new Vector3 (randDir.x, randDir.y, 0);
			Camera.main.transform.localPosition = randDir * shakeIntensity.Evaluate(shake/duration);
			Camera.main.transform.localPosition += startingCameraPos;
			shake -= Time.deltaTime * decreaseFactor;

		} else {
			shake = 0.0f;
			Camera.main.transform.position = startingCameraPos;
		}
	}

	public void Shake(float dur, float amount = 0.5f){
		duration = dur;
		shake = duration;
		shakeAmount = amount;
		//startingCameraPos = Camera.main.transform.position;
	}
}
