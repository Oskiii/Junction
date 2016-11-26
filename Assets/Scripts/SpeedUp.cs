using UnityEngine;
using System.Collections;
using System;

public class SpeedUp : MonoBehaviour, PowerUp {

	private float duration = 50000;
	private float speedBonus = 50;
    private bool timerOn = false;

    public GameObject getGameObject()
    {
        return gameObject;
    }

    public void PickUp(Player player) {
        player.GetInventory().Add(this);

	}

    public void Use(Player player) {
        print("Speed up used");
        float startTime = Time.time;

        player.AddSpeed(speedBonus);
        //wait
        print("Speed up ended");
        player.AddSpeed(-speedBonus);
    }
}
