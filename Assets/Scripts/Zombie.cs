using UnityEngine;
using System.Collections;
using System;

public class Zombie : MonoBehaviour, IDamageable, IMoveable {

    public string Name;
    public float MoveSpeed;
    public bool ShouldMove;
	[SerializeField] private float lifeTime;

    [SerializeField] private int DefaultHealth = 2;
    private int health;
    private Vector2 moveDir;
    [SerializeField] private GameObject ZombieObject;
    private Rigidbody2D rb;
    private BoxCollider2D box2d;

    public void Resurrection(Vector2 direction)
    {
		if (health <= 0) {
			box2d.enabled = true;
			moveDir = direction;
			health = DefaultHealth;
			ShouldMove = true;
			StartCoroutine(Live());
		}
    }

	IEnumerator Live(){
		yield return new WaitForSeconds (lifeTime);
		Die ();
	}

    public void Die() {
        print("debug");
        box2d.enabled = false;
        rb.velocity = Vector2.zero;
        health = 0;
        ShouldMove = false;
    }

    public void Move()
    {
        rb.velocity = (moveDir * MoveSpeed);

        if (moveDir != Vector2.zero)
            ZombieObject.transform.up = moveDir;
    }

    public void TakeDamage(int amount)
    
    {
        if(health <= 0)
        {
            box2d.enabled = false;
        }
        else if(health > 0)
        {
            health -= amount;
            print(health);
            if(health <= 0)
            {
                Die();
            }
        }
    }

    // Use this for initialization
    void Start () {
        health = 0;
        rb = GetComponent<Rigidbody2D>();
        box2d = ZombieObject.GetComponent<BoxCollider2D>();
        box2d.enabled = false;
        ShouldMove = false;
	}

    void Update()
    {
        if(ShouldMove == true)
        {
            Move();
        }
        
    }
}
