using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour {

    public Player player;
    private Vector2 dir;

	void Update () {
        transform.position = player.transform.position;
	}

	public void SetDirection(Vector2 dir){
		if(dir != Vector2.zero)
			transform.up = dir;
	}

    public Vector2 getDir() {
        return dir;
    }
}
