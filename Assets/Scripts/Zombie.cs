using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Zombie : MonoBehaviour, IDamageable, IMoveable {

    public string Name;
	[SerializeField] private float DefaultMoveSpeed;
	private float MoveSpeed;

    public bool ShouldMove;
	[SerializeField] private float lifeTime;

    [SerializeField] private int DefaultHealth = 2;
    private int health;
    private Vector2 moveDir;
    [SerializeField] private GameObject ZombieObject;
    private Rigidbody2D rb;
    private BoxCollider2D box2d;
	private Animator anim;
	private Slider healthbar;

    public void Resurrection(Vector2 direction)
    {
		if (health <= 0) {
			box2d.enabled = true;
			moveDir = direction;
			health = DefaultHealth;
			MoveSpeed = DefaultMoveSpeed;
			ShouldMove = true;
			StartCoroutine(Live());
			anim.SetTrigger ("Resurrect");
			anim.SetBool ("Move", true);
			healthbar.gameObject.SetActive (true);
			SetHealthBar (DefaultHealth);
		}
    }

	IEnumerator Live(){
		for (float t = 1.0f; t > 0.0f; t -= Time.deltaTime / lifeTime)
		{
			MoveSpeed = Mathf.Lerp(0.0f, 1.0f, t);
			yield return null;
		}
		Die ();
	}

    public void Die() {
        print("died");
        box2d.enabled = false;
        rb.velocity = Vector2.zero;
        health = 0;
        ShouldMove = false;
		anim.SetBool ("Move", false);
		anim.SetTrigger ("Die");
		healthbar.gameObject.SetActive (false);
		SetHealthBar (0);
    }

    public void Move()
    {
		rb.velocity = (moveDir * MoveSpeed);
		anim.SetBool ("Move", true);

    }

    public void TakeDamage(int amount)
    
    {
		health -= amount;
		SetHealthBar (health);
        if(health <= 0)
        {
            box2d.enabled = false;
			Die();
        }
    }

	void SetHealthBar(int value){
		healthbar.GetComponent<Slider> ().value = value;
		print (healthbar.GetComponent<Slider> ().value);
	}

    // Use this for initialization
    void Start () {
        health = 0;
        rb = GetComponent<Rigidbody2D>();
        box2d = ZombieObject.GetComponent<BoxCollider2D>();
        box2d.enabled = false;
        ShouldMove = false;
		anim = GetComponent<Animator> ();
		healthbar = GUIManager.Instance.SpawnHealthBar(transform);
		healthbar.maxValue = DefaultHealth;
		SetHealthBar (health);
		healthbar.gameObject.SetActive (false);
	}

    void Update()
    {
        if(ShouldMove == true)
        {
            Move();
        }
        
    }
}
