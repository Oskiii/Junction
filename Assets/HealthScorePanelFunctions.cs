using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScorePanelFunctions : MonoBehaviour {

	[SerializeField] private Text healthText;
	[SerializeField] private Text scoreText;

	public void AddHealth(int h){
		healthText.text += h.ToString ();
	}

	public void AddScore(int s){
		scoreText.text += s.ToString ();
	}
}
