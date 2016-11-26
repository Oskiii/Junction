using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour, PowerUp {
	
	private int amount = 1;
    private float duration = 2;

	public void PickUp(Player player) {

        player.GetInventory().Add(this);
        Destroy(gameObject);
	}

    public IEnumerator Use(Player player)
    {
        player.setInvurnerable(true);
        yield return new WaitForSeconds(duration);
        player.setInvurnerable(false);
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }
}
