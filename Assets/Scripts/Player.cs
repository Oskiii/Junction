using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IDamageable, IMoveable {

	private Vector2 moveDir;
	public string Name;
	private int health;
	public float moveSpeed;
	[SerializeField] private GameObject Character;
	private Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		Move ();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
	}

    public void AddHealth(int amount)
    {
        health += amount;
    }

    public void AddSpeed(float amount)
    {
        moveSpeed += amount;
    }

    public Inventory GetInventory() {
        return GetComponent<Inventory>();
    }

	#region IMoveable implementation
	public void Move ()
	{
		
		moveDir = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;
		rb.velocity = (moveDir * moveSpeed);

		if(moveDir != Vector2.zero)
			Character.transform.up = moveDir;
		
	}

    public void Interact()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(rb.position, 2);
        for(int i = 0; i < colliders.Length; i++)
        {
            Collider2D call = colliders[i];
            if(call.GetComponent<Zombie>() != null)
            {
                call.GetComponent<Zombie>().Resurrection(moveDir);
            }
        }

        
    }
	#endregion


	#region IDamageable implementation

	public void TakeDamage (int amount)
	{
		throw new System.NotImplementedException ();
	}

	#endregion
}
