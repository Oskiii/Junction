using UnityEngine;
using System.Collections;
using System;

public class SpeedUp : MonoBehaviour, PowerUp {

    [SerializeField] Sprite sprite;
	private float duration = 5;
	private float speedBonus = 5;
    private bool timerOn = false;

    public GameObject getGameObject()
    {
        return gameObject;
    }

    public Sprite getSprite()
    {
        return sprite;
    }

    public void PickUp(Player player) {
        player.GetInventory().Add(this);
        Destroy(gameObject);
	}

    public IEnumerator Use(Player player) {
        player.AddSpeed(speedBonus);
        yield return new WaitForSeconds(duration);
        player.AddSpeed(-speedBonus);
    }
}
