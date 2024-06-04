using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items= new List<Item>(); //represents inventory
    public int numOfKeys;
    public int numOfCaps;

    public void AddItem(Item newItem)
    {
        if (newItem.isKey)
        {
            numOfKeys++;
        }
        else
        {
            if(!items.Contains(newItem))
            {
                items.Add(newItem);
            }
        }
    }
   
}
