using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	[SerializeField] private List<Image> inventorySlots;
    [SerializeField] private GameObject GameOver;
    public static GUIManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void SetInventoryImage(int slot, Sprite spr){
		inventorySlots [slot].sprite = spr;
	}

    public void ShowGameOverScreen()
    {
        GameOver.SetActive(true);
    }
}
