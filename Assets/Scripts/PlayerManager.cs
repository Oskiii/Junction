using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

	[SerializeField] private GameObject playerObject;
	public int PlayerAmount;
	public List<Player> PlayerObjects;
	public static PlayerManager Instance;

	void Awake(){
		Instance = this;
	}

	void Start () {
		for (int i = 0; i < PlayerAmount; i++) {
			GameObject player = Instantiate (playerObject);
			PlayerObjects.Add (player.GetComponent<Player>());
		}
	}
}
