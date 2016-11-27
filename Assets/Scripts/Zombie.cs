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
	[SerializeField] private AnimationClip zombieDieAnim;

    public void Resurrection(Vector2 direction)
    {
		if (health <= 0) {
			box2d.enabled = true;
			moveDir = direction;
			health = DefaultHealth;

			anim.SetTrigger ("Resurrect");
			anim.SetInteger ("ResDir", Mathf.FloorToInt (Mathf.Sign (direction.x)));
		}
    }

	public void StartLiving(){
		StartCoroutine (Live ());
	}

	IEnumerator Live(){
		SetMoveAnim ();
		MoveSpeed = DefaultMoveSpeed;
		ShouldMove = true;
		healthbar.gameObject.SetActive (true);
		SetHealthBar (DefaultHealth);
		print ("lifetime: " + lifeTime);
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
		anim.SetInteger ("Move", 0);
		anim.SetTrigger ("Die");
		healthbar.gameObject.SetActive (false);
		SetHealthBar (0);
    }

    public void Move()
    {
		rb.velocity = (moveDir * MoveSpeed);
		SetMoveAnim ();

    }

	void SetMoveAnim(){
		anim.SetInteger ("Move", Mathf.FloorToInt(Mathf.Sign(moveDir.x)));
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
