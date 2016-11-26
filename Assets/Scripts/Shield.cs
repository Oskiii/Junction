using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour, PowerUp {
	
	private int amount = 1;

	public void PickUp(Player player) {
		
		player.AddHealth (amount);
		Destroy (gameObject);
	}

    public IEnumerator Use(Player player)
        //not an usable item
    {
        yield return new WaitForSeconds(0);
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }
}
