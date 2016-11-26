﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour, IMoveable {

	GameObject currentTarget;
	Rigidbody2D rb;
	public float moveSpeed;
    public int damage = 1;
	bool ShouldMove = true;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		SelectTarget ();
	}

	#region IMoveable implementation

	public void Move ()
	{
        Vector2 moveDir = (currentTarget.transform.position - transform.position).normalized;

        rb.velocity = moveDir * moveSpeed;
        if (moveDir != Vector2.zero)
            transform.up = -moveDir;
    }

    #endregion

    void SelectTarget(){
		
		currentTarget = PlayerManager.Instance.PlayerObjects [Random.Range (0, PlayerManager.Instance.PlayerObjects.Count-1)].gameObject;
		ShouldMove = true;
	}

	void Update(){
		if (currentTarget != null && ShouldMove) {
			Move ();
		}
    
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            
            Destroy(gameObject);
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
        if (collision.collider.tag == "Zombie")
        {
            
            Destroy(gameObject);
            collision.gameObject.GetComponent<Zombie>().TakeDamage(damage);
			GUIManager.Instance.GetHealthScorePanel (0).AddScore (1);
        }
    }
}
