using UnityEngine;
using System.Collections;

public interface PowerUp {

    void PickUp(Player player);

    IEnumerator Use(Player player);

    GameObject getGameObject();
}
