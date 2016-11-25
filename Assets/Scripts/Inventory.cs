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
            for (int i=0; i<4; i++)
            {
                if (powerUps[i] == null)
                {
                    powerUps[i] = powerup;
                    nofPowerUps += 1;
                }
            }
        }
	}

	public void Use(int button, Player player) { // 0 = O, 1 = kolmio, 2 = nelio, 3 = x
        if (button <= 3 && button >= 0)
        { 
            if(powerUps != null && powerUps[button] != null)
            {
                powerUps[button].Use(player);
                powerUps[button] = null;
                nofPowerUps -= 1;
            }
        }
	}
}
