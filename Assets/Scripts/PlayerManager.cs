﻿using UnityEngine;
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

	void Start(){

		SpawnPlayers ();
	}

	void SpawnPlayers () {
		for (int i = 0; i < PlayerAmount; i++) {
			GameObject player = Instantiate (playerObject);
			player.transform.position = Camera.main.ScreenToWorldPoint (new Vector2(Screen.width / 2, Screen.height / 2));
			PlayerObjects.Add (player.GetComponent<Player>());
			player.GetComponent<Player> ().playerID = i;
		}
	}
    
    void GameOver()
    {

    }
}
