using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    [SerializeField] Sprite defaultSprite;
    private int[] order = { 0, 2, 3, 1 };
    private PowerUp[] powerUps = { null, null, null, null };
    private int nofPowerUps = 0;

    public void Add(PowerUp powerup)
    {
        if (nofPowerUps < 4)
        {
            foreach (int i in order)
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
    { 
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
