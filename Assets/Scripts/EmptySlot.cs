using UnityEngine;
using System.Collections;
using System;

public class EmptySlot : MonoBehaviour, PowerUp
{
    public void PickUp(Player player)
    {
        throw new NotImplementedException();
    }

    public void Use(Player player)
    {
        throw new NotImplementedException();
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }
}
