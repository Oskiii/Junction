using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour, IMoveable {

	GameObject currentTarget;
	Rigidbody2D rb;
	public float moveSpeed;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	#region IMoveable implementation

	public void Move ()
	{
		rb.velocity = (currentTarget * moveSpeed);
	}

	#endregion

	void SelectTarget(){
		
		currentTarget = PlayerManager.Instance.PlayerObjects [Random.Range (0, PlayerManager.Instance.PlayerObjects.Count-1)];
	}

	void Update(){
		if (currentTarget != null) {
			Move ();
		}
	}
}
