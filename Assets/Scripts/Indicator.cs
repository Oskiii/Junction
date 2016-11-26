using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour {

    [SerializeField] Player player;
    private Vector2 dir;

	void Update () {
        transform.position = player.transform.position;
        //dir oikean tatin mukaan
	}
}
