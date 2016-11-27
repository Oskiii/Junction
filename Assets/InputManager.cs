using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public static float MoveHorizontal;
	public static float MoveVertical;

	public static float AimHorizontal;
	public static float AimVertical;

	void Update() {
		if(Input.GetAxis ("P1MoveHorizontal") == 1 || Input.GetAxis ("P1MoveHorizontalKeyboard") == 1) { MoveHorizontal = 1; } else { MoveHorizontal = 0; }
		if(Input.GetAxis ("P1MoveHorizontal") == -1 || Input.GetAxis ("P1MoveHorizontalKeyboard") == -1) { MoveHorizontal = -1; } else { MoveHorizontal = 0; }
		if(Input.GetAxis ("P1MoveVertical") == 1 || Input.GetAxis ("P1MoveVerticalKeyboard") == 1) { MoveVertical = 1; } else { MoveVertical = 0; }
		if(Input.GetAxis ("P1MoveVertical") == -1 || Input.GetAxis ("P1MoveVerticalKeyboard") == -1) { MoveVertical = -1; } else { MoveVertical = 0; }

		if(Input.GetAxis ("P1AimHorizontal") == 1 || Input.GetAxis ("P1AimHorizontalKeyboard") == 1) { AimHorizontal = 1; } else { AimHorizontal = 0; }
		if(Input.GetAxis ("P1AimHorizontal") == -1 || Input.GetAxis ("P1AimHorizontalKeyboard") == -1) { AimHorizontal = -1; } else { AimHorizontal = 0; }
		if(Input.GetAxis ("P1AimVertical") == 1 || Input.GetAxis ("P1AimVerticalKeyboard") == 1) { AimVertical = 1; } else { AimVertical = 0; }
		if(Input.GetAxis ("P1AimVertical") == -1 || Input.GetAxis ("P1AimVerticalKeyboard") == -1) { AimVertical = -1; } else { AimVertical = 0; }
	}
}
