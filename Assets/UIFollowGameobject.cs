using UnityEngine;
using System.Collections;

public class UIFollowGameobject : MonoBehaviour {

	[SerializeField] private Transform target;

	void Update(){
		var wantedPos = Camera.main.WorldToScreenPoint (target.position + new Vector3(0, 1f, 0));
		transform.position = wantedPos;
	}

	public void SetTarget (Transform t){
		target = t;
	}
}
