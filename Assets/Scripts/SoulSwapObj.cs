using UnityEngine;
using System.Collections;

public class SoulSwapObj : MonoBehaviour {

    private float MoveSpeed = 5;
    private Rigidbody2D rb;
    private Vector2 dir;
    private bool shot = false;

	void Update() {
        if (shot)
        {
            rb.velocity = (dir * MoveSpeed);
        }
    }

    public void shoot(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        dir = direction;
        shot = true;
    }
}
