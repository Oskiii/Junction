﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour{

	[SerializeField] private List<Image> inventorySlots;
    [SerializeField] private GameObject GameOver;
	[SerializeField] private Text health;
	[SerializeField] private Text score;
	[SerializeField] private GameObject InventoryObject;
	[SerializeField] private GameObject InventoryParent;
	[SerializeField] private GameObject ScoreObject;
	[SerializeField] private GameObject ScoreParent;
    public static GUIManager Instance;

    void Awake()
    {
        Instance = this;
    }

	void Start(){
		AddHealth (0, 0);
		AddScore (0, 0);
	}

	public void CreatePlayerUI(){
		GameObject ob = (GameObject)Instantiate (InventoryObject);
		ob.transform.SetParent (InventoryParent.transform, false);
		ob = (GameObject)Instantiate (ScoreObject);
		ob.transform.SetParent (ScoreParent.transform, false);
	}

    void SetInventoryImage(int slot, Sprite spr){
		inventorySlots [slot].sprite = spr;
	}

    public void ShowGameOverScreen()
    {
        GameOver.SetActive(true);
    }

	public void AddHealth(int playerID, int amount){
		health.text = (int.Parse(health.text) + amount).ToString();
	}

	public void AddScore(int playerID, int amount){
		score.text = (int.Parse(score.text) + amount).ToString();
	}
}
