using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour {

    [SerializeField] Player player;
    private Vector2 dir;

    public Indicator(Player p)
    {
        player = p;
    }

	void Update () {
        transform.position = player.transform.position;
        print("TEST");
	}
}
