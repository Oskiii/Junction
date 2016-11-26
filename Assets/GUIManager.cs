using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	[SerializeField] private List<Image> inventorySlots;

	void SetInventoryImage(int slot, Sprite spr){
		inventorySlots [slot].sprite = spr;
	}
}
