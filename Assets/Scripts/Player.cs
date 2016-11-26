using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IDamageable, IMoveable {

	private Vector2 moveDir;
	public string Name;
	private int health = 3;
    private int lives = 3;
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

    public void kill()
    {
        lives -= 1;
        if (lives <= 0)
        {
            
        }
        
    }

    public Inventory GetInventory() {
        return GetComponent<Inventory>();
    }

	#region IMoveable implementation
	public void Move ()
	{
		
		moveDir = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;
		rb.velocity = (moveDir * moveSpeed);

		/*if(moveDir != Vector2.zero)
			Character.transform.up = moveDir;*/
		
	}
    #endregion
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
		throw new System.NotImplementedException ();
	}

	#endregion
}
