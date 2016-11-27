using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

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

	void Update() {
		if (shake > 0) {
			Camera.main.transform.localPosition = Random.insideUnitSphere * shakeIntensity.Evaluate(shake/duration);
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
		startingCameraPos = Camera.main.transform.position;
	}
}
