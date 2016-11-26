using UnityEngine;
using System.Collections;

public interface PowerUp {

    Sprite getSprite();

    void PickUp(Player player);

    IEnumerator Use(Player player);

    GameObject getGameObject();
}
