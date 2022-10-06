using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//inventory
public class MenuContent : MonoBehaviour
{
    Text[] slots;
    [SerializeField] int[] inventory = {0,1,2,4,5,1};
    PlayerManager playerManager;
    void Awake()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        slots = GetComponentsInChildren<Text>();
        
    }
    
    public void LoadInventory()
    {
        //test
        int[] timeInv = {0,0,0,0,0,0};
        //

        //make from 0,0,0,1,0,2 this 1,2,0,0,0,0
        int j = 0;
        for(int i = 0; i < 6; i++)
        {
			if (playerManager.sessionSave.inventory[i] != 0)
			{
				timeInv[j] = playerManager.sessionSave.inventory[i];
				j++;
			}
		}
        playerManager.sessionSave.inventory = timeInv;
        /*
        for(int i = 0, iInInv = 0; i < inv.Length; i++)
        {
            int k = -1;
            for(; iInInv <= 6; iInInv++)
            {
                if(playerManager.sessionSave.inventory[iInInv] != 0)
                {
                    k = playerManager.sessionSave.inventory[iInInv];
                    break;
                }
            }
            if(k == -1) break;
            else
            {
                inv[i] = k;
                sorted = true;
            }
        }
        */
        


        int k = 0;
        for(int i = 0; i < timeInv.Length; i++)
        {
            if(GetItemId(timeInv[i]) != "skip")
            {
                slots[k].text = GetItemId(timeInv[i]);
                k++;
            }
        }
        for(int i = k; i < timeInv.Length; i++)
        {
            slots[i].text = "";
        }
    }

    string GetItemId(int id)
    {
        switch(id)
        {
            case 1:
            return "apple";

            case 2:
            return "pie";

            case 3:
            return "alabama";

            case 4:
            return "flower";

            case 5:
            return "tent";
            default:
            return "skip";
        }
    }
}
