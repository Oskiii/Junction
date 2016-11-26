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
	[SerializeField] private Transform healthBarParent;
	[SerializeField] private GameObject healthbarObject;

    void Awake()
    {
        Instance = this;
    }

	void Start(){
		inventories = new List<InventoryPanelFunctions> ();
		healthScores = new List<HealthScorePanelFunctions> ();
		for(int i = 0; i < PlayerManager.Instance.PlayerAmount; i++){
			CreatePlayerUI ();
		}
	}

	public Slider SpawnHealthBar(Transform target){
		GameObject obj = (GameObject)Instantiate (healthbarObject);
		obj.GetComponent<UIFollowGameobject> ().SetTarget (target);
		obj.transform.SetParent (healthBarParent, false);
		obj.transform.position = target.position;
		return obj.GetComponent<Slider>();
	}

	public InventoryPanelFunctions GetInventoryPanel(int playerID){
		return inventories [playerID];
	}

	public HealthScorePanelFunctions GetHealthScorePanel(int playerID){
		print (healthScores.Count);
		return healthScores [playerID];
	}

	public void CreatePlayerUI(){
		GameObject ob = (GameObject)Instantiate (InventoryObject);
		ob.transform.SetParent (InventoryParent.transform, false);
		inventories.Add(ob.GetComponent<InventoryPanelFunctions>());
		ob = (GameObject)Instantiate (ScoreObject);
		ob.transform.SetParent (ScoreParent.transform, false);
		healthScores.Add(ob.GetComponent<HealthScorePanelFunctions>());
	}

    public void ShowGameOverScreen()
    {
        GameOver.SetActive(true);
    }
		
}
