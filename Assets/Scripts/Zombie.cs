using UnityEngine;
using System.Collections;
using System;

public class Zombie : MonoBehaviour, IDamageable, IMoveable {

    public string Name;
    public float MoveSpeed;
    public bool ShouldMove;

    [SerializeField] private int DefaultHealth = 1;
    private int health;
    private Vector2 moveDir;
    [SerializeField] private GameObject ZombieObject;
    private Rigidbody2D rb;

    public void Resurrection(Vector2 direction)
    {
        moveDir = direction;
        health = DefaultHealth;
        ShouldMove = true;
    }

    public void Move()
    {
        rb.velocity = (moveDir * MoveSpeed);

        if (moveDir != Vector2.zero)
            ZombieObject.transform.up = moveDir;
    }

    public void TakeDamage(int amount)
    
    {
        health -= amount;
    }

    // Use this for initialization
    void Start () {
        health = 0;
        rb = GetComponent<Rigidbody2D>();
        ShouldMove = false;
	}

    void Update()
    {
        if(ShouldMove == true)
        {
            Move();
        }
    }
	
	// Update is called once per frame
}
