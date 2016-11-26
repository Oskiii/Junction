﻿using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    [SerializeField] Sprite defaultSprite;
    private PowerUp[] powerUps = { null, null, null, null };
    private int nofPowerUps = 0;

    public void Add(PowerUp powerup)
    {
        if (nofPowerUps < 4)
        {
            for (int i = 0; i < 4; i++)
            {
                if (powerUps[i] == null)
                {
                    powerUps[i] = powerup;
                    nofPowerUps += 1;
                    GUIManager.Instance.GetInventoryPanel(GetComponent<Player>().playerID).SetInventoryImage(i, powerup.getSprite());
                    break;
                }
            }
        }
    }

    public void Use(int button, Player player)
    { // 0 = O, 1 = kolmio, 2 = nelio, 3 = x
        if (button <= 3 && button >= 0)
        {
            if (powerUps[button] != null)
            {
                StartCoroutine(powerUps[button].Use(player));
                powerUps[button] = null;
                nofPowerUps -= 1;
                GUIManager.Instance.GetInventoryPanel(GetComponent<Player>().playerID).SetInventoryImage(button, defaultSprite);
            }
        }
    }
}
