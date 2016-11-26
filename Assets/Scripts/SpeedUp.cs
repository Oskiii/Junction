using UnityEngine;
using System.Collections;
using System;

public class SpeedUp : MonoBehaviour, PowerUp {

	private float duration = 5;
	private float speedBonus = 5;
    private bool timerOn = false;

    public GameObject getGameObject()
    {
        return gameObject;
    }

    public void PickUp(Player player) {
        player.GetInventory().Add(this);

	}

    public IEnumerator Use(Player player) {
        print("Speed up used");
        float startTime = Time.time;

        player.AddSpeed(speedBonus);
        yield return new WaitForSeconds(duration);
        print("Speed up ended");
        player.AddSpeed(-speedBonus);
    }
}
