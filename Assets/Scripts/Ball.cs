using UnityEngine;
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
        float angle = (Mathf.Atan2(moveDir.y, moveDir.x) * 180/Mathf.PI + 270) % 360;
        print(angle);
        rb.velocity = moveDir * moveSpeed;
        if (22.5 > angle || angle > 337.5)
        {
            moveDir = new Vector2(0, 1);
        }
        else if (angle < 67.5)
        {
            moveDir = new Vector2(-1, 1).normalized;
        }
        else if (angle < 112.5)
        {
            moveDir = new Vector2(-1, 0);
        }
        else if ( angle < 157.5)
        {
            moveDir = new Vector2(-1, -1).normalized;
        }
        else if (angle < 202.5)
        {
            moveDir = new Vector2(0, -1);
        }
        else if (angle < 247.5)
        {
            moveDir = new Vector2(1, -1).normalized;
        }
        else if (angle < 292.5)
        {
            moveDir = new Vector2(1, 0);
        }
        else
        {
            moveDir = new Vector2(1, 1).normalized;
        }
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
