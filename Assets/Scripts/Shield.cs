using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour, PowerUp {
	
	private int amount = 1;

	public void PickUp(Player player) {
		
		player.AddHealth (amount);
		Destroy (gameObject);
	}

    public void Use(Player player)
        //not an usable item
    {

    }

}
