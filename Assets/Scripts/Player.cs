using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IDamageable, IMoveable {

	private Vector2 moveDir;
	public string Name;
	public int playerID;
	private int health = 3;
    private int lives = 3;
	[SerializeField] private float moveSpeed;
	[SerializeField] private GameObject Character;
	private Rigidbody2D rb;
	private Animator anim;
    private bool invurnerable = false;
	private bool facingRight = false;
    [SerializeField] private GameObject arrowObject;
	private Indicator aimArrow;
	public Vector2 aimDirection;
    private AudioSource[] sounds;
    private float stepTimer;
    private float interactCD = 3;

    void Start(){
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		GameObject g = (GameObject) Instantiate(arrowObject, transform.position, transform.rotation);
		g.GetComponent<Indicator> ().player = this;
		aimArrow = g.GetComponent<Indicator> ();
        sounds = GetComponents<AudioSource>();
    }

	void Update(){
        interactCD -= Time.deltaTime;
        Move ();
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Z)) { GetComponent<Inventory>().Use(0, this); }
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.X)) { GetComponent<Inventory>().Use(1, this); }
        if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.C)) { GetComponent<Inventory>().Use(2, this); }
        if (Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.V)) { GetComponent<Inventory>().Use(3, this); }

		/*aimDirection = new Vector2 (Input.GetAxis ("P1AimHorizontalKeyboard"), Input.GetAxis ("P1AimVerticalKeyboard"));*/
		aimDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

		aimArrow.SetDirection(aimDirection);
        stepTimer -= Time.deltaTime;
        if (rb.velocity != Vector2.zero && stepTimer < 0)
        {
            sounds[Random.Range(4, 6)].Play();
            stepTimer = 0.25f;
        }
    }

	public void Shove(Vector2 dir){
		print ("shoved player back");
		rb.AddForce(dir*15);
	}

    public void AddHealth(int amount)
    {
        health += amount;
		GUIManager.Instance.GetHealthScorePanel (playerID).AddHealth (amount);
    }

    public void AddSpeed(float amount)
    {
        moveSpeed += amount;
    }

    public void Die()
    {
        lives -= 1;
		anim.SetTrigger ("Death");
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
		
		moveDir = new Vector2 (Input.GetAxisRaw ("P1MoveHorizontalKeyboard"), Input.GetAxisRaw ("P1MoveVerticalKeyboard")).normalized;
		rb.velocity = (moveDir * moveSpeed);

		if (rb.velocity != Vector2.zero) {
			SetMoveAnim ();

			if (moveDir.x > 0 && !facingRight) {
				anim.SetBool ("FaceRight", true);
			} else if (moveDir.x < 0 && facingRight) {
				anim.SetBool ("FaceRight", false);
			}

		} else {
			SetMoveAnimIdle ();
			anim.SetBool ("FaceRight", false);
		}
		
	}
    #endregion

	void SetMoveAnim(){
		anim.SetInteger ("Move", Mathf.FloorToInt(Mathf.Sign(moveDir.x)));
	}

	void SetMoveAnimIdle(){
		anim.SetInteger ("Move", 0);
	}

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
        print(interactCD);
        if (interactCD < 0)
        {

            Collider2D[] colliders = Physics2D.OverlapCircleAll(rb.position, (float)0.5);
            for (int i = 0; i < colliders.Length; i++)
            {

                Collider2D call = colliders[i];

                if (call.GetComponent<Zombie>() != null)
                {
                    call.GetComponent<Zombie>().Resurrection((/*call.transform.position - Character.transform.position*/aimDirection).normalized);
                    anim.SetTrigger("Resurrection");
                    sounds[Random.Range(6, 8)].Play();
                    interactCD = 3;
                }

            }
        }
    }

    public Indicator getIndicator()
    {
        return aimArrow;
    }
	


	#region IDamageable implementation

	public void TakeDamage (int amount)
	{
        if (!invurnerable)
        {
            health -= amount;
			CameraShake.Instance.Shake (0.3f, 0.4f);
			GUIManager.Instance.ScreenFlash (0.08f);

            if(health <= 0)
            {
                Die();
            }
            sounds[Random.Range(1, 3)].Play(); //pain
            sounds[3].Play();                 //fireball hit
        }
        
	}

	#endregion
}
