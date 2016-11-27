using UnityEngine;
using System.Collections;

public class PickUpPowerUps : MonoBehaviour {
    [SerializeField]
    private Player player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PowerUp>() != null)
        {
            other.gameObject.GetComponent<PowerUp>().PickUp(player);
        }
    }
}
