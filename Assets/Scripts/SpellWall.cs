using UnityEngine;
using System.Collections;
using System;

public class SpellWall : MonoBehaviour, PowerUp
{

    [SerializeField] Sprite sprite;
    [SerializeField] GameObject wall;
    private float duration = 5;
    private float distance = 500;

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
        UnityEngine.Object obj = Instantiate(wall, player.transform.position + player.transform.forward * distance, player.transform.rotation);
        yield return new WaitForSeconds(duration);
        Destroy(obj);
    }
}
