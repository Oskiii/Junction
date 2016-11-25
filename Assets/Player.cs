using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IDamageable {

	private Vector2 moveDir;
	public string Name;
	private int health;
	public float moveSpeed;
	[SerializeField] private GameObject Character;

	void Update(){
		moveDir = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;
		transform.Translate (moveDir * moveSpeed);

		if(moveDir != Vector2.zero)
			Character.transform.up = -moveDir;

	}

	#region IDamageable implementation

	public void TakeDamage (int amount)
	{
		throw new System.NotImplementedException ();
	}

	#endregion
}
