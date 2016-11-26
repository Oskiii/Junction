using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IDamageable, IMoveable {

	private Vector2 moveDir;
	public string Name;
	private int health = 3;
    private int lives = 3;
	[SerializeField] private float moveSpeed;
	[SerializeField] private GameObject Character;
	private Rigidbody2D rb;
	private Animator anim;
    private bool invurnerable = false;
	private bool facingRight = true;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update(){
		Move ();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
        if (Input.GetKeyDown(KeyCode.Z)) { GetComponent<Inventory>().Use(0, this); }
        if (Input.GetKeyDown(KeyCode.X)) { GetComponent<Inventory>().Use(1, this); }
        if (Input.GetKeyDown(KeyCode.C)) { GetComponent<Inventory>().Use(2, this); }
        if (Input.GetKeyDown(KeyCode.V)) { GetComponent<Inventory>().Use(3, this); }
    }

    public void AddHealth(int amount)
    {
        health += amount;
    }

    public void AddSpeed(float amount)
    {
        moveSpeed += amount;
    }

    public void Die()
    {
        lives -= 1;
        if (lives <= 0)
        {
            GameManager.Instance.GameOver();
        }
        
    }

    public Inventory GetInventory() {
        return GetComponent<Inventory>();
    }

    public void setInvurnerable(bool boo)
    {
        invurnerable = boo;
    }

	#region IMoveable implementation
	public void Move ()
	{
		
		moveDir = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;
		rb.velocity = (moveDir * moveSpeed);

		if (rb.velocity != Vector2.zero) {
			anim.SetBool ("Walk", true);

			if (rb.velocity.x > 0 && !facingRight) {
				FlipSprite ();
			} else if (rb.velocity.x < 0 && facingRight) {
				FlipSprite ();
			}

		} else {
			anim.SetBool ("Walk", false);
		}

		/*if(moveDir != Vector2.zero)
			Character.transform.up = moveDir;*/
		
	}
    #endregion

	void FlipSprite(){

		Character.transform.localScale = new Vector2(-Character.transform.localScale.x, Character.transform.localScale.y);

		if (facingRight) {
			facingRight = false;
		} else {
			facingRight = true;
		}
	}

    public void Interact()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(rb.position, (float)0.5);
        for(int i = 0; i < colliders.Length; i++)
        {
            Collider2D call = colliders[i];
            if(call.GetComponent<Zombie>() != null)
            {
                call.GetComponent<Zombie>().Resurrection((call.transform.position - Character.transform.position).normalized);
            }
            if(call.GetComponent<PowerUp>() != null) {
                call.GetComponent<PowerUp>().PickUp(this);
            }
        }

        
    }
	


	#region IDamageable implementation

	public void TakeDamage (int amount)
	{
        if (!invurnerable)
        {
            health -= amount;
            if(health <= 0)
            {
                Die();
            }
        }
        
	}

	#endregion
}
