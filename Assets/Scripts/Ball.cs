using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour, IMoveable {

	GameObject currentTarget;
	Rigidbody2D rb;
	public float moveSpeed;
    public int damage = 1;
	bool ShouldMove = true;
	Vector2 moveDir;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		SelectTarget ();
	}

	#region IMoveable implementation

	public void Move ()
	{
		moveDir = (currentTarget.transform.position - transform.position).normalized;
        float angle = (Mathf.Atan2(moveDir.y, moveDir.x) * 180/Mathf.PI + 270) % 360;
		moveDir = -transform.up;

		if (20 > angle || angle > 340) {
			moveDir = new Vector2 (0, 1);
		} else if (angle < 25) {
		} else if (angle < 65) {
			moveDir = new Vector2 (-1, 1).normalized;
		} else if (angle < 70) {
		} else if (angle < 110) {
			moveDir = new Vector2 (-1, 0);
		} else if (angle < 115) {
		} else if (angle < 155) {
			moveDir = new Vector2 (-1, -1).normalized;
		} else if (angle < 160) {
		} else if (angle < 200) {
			moveDir = new Vector2 (0, -1);
		} else if (angle < 205) {
		} else if (angle < 245) {
			moveDir = new Vector2 (1, -1).normalized;
		} else if (angle < 250) {
		} else if (angle < 290) {
			moveDir = new Vector2 (1, 0);
		} else if (angle < 295) {
		} else if(angle < 335)
        {
            moveDir = new Vector2(1, 1).normalized;
        }
        transform.up = -moveDir;
		rb.velocity = moveDir * moveSpeed;
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
			Player p = collision.gameObject.GetComponent<Player> ();
            p.TakeDamage(damage);
			p.Shove (moveDir * 20);
			Destroy(gameObject);
        }
        if (collision.collider.tag == "Zombie")
        {
            
            Destroy(gameObject);
            collision.gameObject.GetComponent<Zombie>().TakeDamage(damage);
			//GUIManager.Instance.GetHealthScorePanel (0).AddScore (1);
        }
		if (collision.collider.tag == "Ball") {
			if (collision.collider.transform.position.x > transform.position.x) {
				Destroy (gameObject);
			}
			moveSpeed *= Mathf.Max(moveSpeed, collision.collider.GetComponent<Ball>().moveSpeed) * 1.5f;
		}
    }
}
