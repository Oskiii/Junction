using UnityEngine;
using System.Collections;
using System;

public class SoulSwap : MonoBehaviour, PowerUp
{

    [SerializeField] Sprite sprite;
    private float duration = 3;

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
        
        yield return new WaitForSeconds(duration);
        
    }
}
