using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;

    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void Setup(InventoryItem item, InventoryManager manager)
    {
        thisItem = item;
        thisManager=manager;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text = "" + thisItem.itemNumber;
        }
    }

   public void ClickedOn()
    {
        if (thisItem)
        {
            thisManager.SetDescAndButton(thisItem.itemDesc, thisItem.usable, thisItem);
        }
    }
}
