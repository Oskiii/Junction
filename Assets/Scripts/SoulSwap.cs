using UnityEngine;
using System.Collections;
using System;

public class SoulSwap : MonoBehaviour, PowerUp
{
    [SerializeField] Sprite sprite;
    [SerializeField] SoulSwapObj obj;

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
        Instantiate(obj, player.transform.position, player.transform.rotation);
        //obj.shoot(INDICATOR DIR);
        yield return new WaitForSeconds(0);
    }
}
