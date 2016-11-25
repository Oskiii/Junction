using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

	[SerializeField] private GameObject playerObject;
	public int PlayerAmount;
	public List<Player> PlayerObjects;

	void Start () {
		for (int i = 0; i < PlayerAmount; i++) {
			Instantiate (playerObject);
		}
	}

	void Update () {
	
	}
}
