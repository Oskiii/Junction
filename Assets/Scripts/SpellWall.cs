using UnityEngine;
using System.Collections;
using System;

public class SpellWall : MonoBehaviour, PowerUp
{

    [SerializeField] Sprite sprite;
    [SerializeField] GameObject wall;
    private float duration = 5;
    private float distance = 1;

    public GameObject getGameObject()
    {
        return gameObject;
    }

    public Sprite getSprite()
    {
        return sprite;
    }

    public void PickUp(Player player)
    {
        player.GetInventory().Add(this);
        Destroy(gameObject);
    }

    public IEnumerator Use(Player player)
    {
		print (Quaternion.Euler (player.aimDirection));
		UnityEngine.Object obj = Instantiate(wall, (Vector2)player.transform.position + (Vector2)player.aimDirection * distance, Quaternion.Euler(player.aimDirection));
        yield return new WaitForSeconds(duration);
        Destroy(obj);
    }
}
