using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryPanelFunctions : MonoBehaviour {

	[SerializeField] private List<Image> inventorySlots;

	public void SetInventoryImage(int slot, Sprite spr){
		inventorySlots [slot].sprite = spr;
	}
}
