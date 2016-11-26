using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour {

    public Player player;
    private Vector2 dir;

	void Update () {
        transform.position = player.transform.position;
	}

	public void SetDirection(Vector2 dir){
		transform.rotation = Quaternion.Euler(dir);
	}
}
