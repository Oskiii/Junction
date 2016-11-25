using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour, PowerUp {

	private float duration = 5;
	private float speedBonus = 1;

	public void PickUp(Player player) {
        player.GetInventory().Add(this);
	}

    public void Use(Player player) {
        float i = duration;

        player.AddSpeed(speedBonus);
        while (i > 0)
        {
            i -= Time.deltaTime;
        }
        player.AddSpeed(-speedBonus);
    }
}
