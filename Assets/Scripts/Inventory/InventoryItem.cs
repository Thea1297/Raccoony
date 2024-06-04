using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName="New Item", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDesc;
    public Sprite itemImage;
    public int itemNumber;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;

    public void Use()
    {
       
            thisEvent.Invoke();
        
    }


    public void DecreaseAmount(int amountToDecrease)
    {
        itemNumber-=amountToDecrease;
        if(itemNumber < 0 )
        {
            itemNumber = 0;
        }
    }
}
