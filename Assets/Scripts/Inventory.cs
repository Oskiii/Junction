using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	private List<PowerUp> powerUps;
    private int nofPowerUps = 0;

    void start()
    {
        powerUps = new List<PowerUp>() {null, null, null, null};
    }

	public void Add(PowerUp powerup) {
		if (nofPowerUps < 4) {
            powerUps.Add(powerup);
            nofPowerUps += 1;
        }
	}

	public void Use(int button) { // 0 = O, 1 = kolmio, 2 = nelio, 3 = x
        switch(button) {
            case 0:
                if (powerUps[0] != null)
                {
                    //use?
                    powerUps[0] = null;
                }
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
	}
}
