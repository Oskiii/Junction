using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour{

    [SerializeField] private GameObject GameOver;
	[SerializeField] private GameObject InventoryObject;
	[SerializeField] private GameObject InventoryParent;
	private List<InventoryPanelFunctions> inventories;
	[SerializeField] private GameObject ScoreObject;
	[SerializeField] private GameObject ScoreParent;
	private List<HealthScorePanelFunctions> healthScores;
    public static GUIManager Instance;

    void Awake()
    {
        Instance = this;
    }

	void Start(){
		for(int i = 0; i < PlayerManager.Instance.PlayerAmount; i++){
			CreatePlayerUI ();
		}
	}

	public InventoryPanelFunctions GetInventoryPanel(int playerID){
		return inventories [playerID];
	}

	public HealthScorePanelFunctions GetHealthScorePanel(int playerID){
		return healthScores [playerID];
	}

	public void CreatePlayerUI(){
		GameObject ob = (GameObject)Instantiate (InventoryObject);
		ob.transform.SetParent (InventoryParent.transform, false);
		ob = (GameObject)Instantiate (ScoreObject);
		ob.transform.SetParent (ScoreParent.transform, false);
	}

    public void ShowGameOverScreen()
    {
        GameOver.SetActive(true);
    }
		
}
