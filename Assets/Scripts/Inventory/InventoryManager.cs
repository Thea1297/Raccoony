using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;


    public void SetTextAndButton(string desc, bool buttonActive)
    {
        descText.text = desc;
        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }

    }

    void MakeInventorySlots()
    {
        if (playerInventory) //36:00 73.
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if (playerInventory.myInventory[i].itemNumber > 0 || playerInventory.myInventory[i].itemName=="Bottle" )
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }

    // OnEnable is called whenever the object goes from disable to enable
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

   public void SetDescAndButton(string newDescString, bool isUsable, InventoryItem newItem )
    {
        currentItem = newItem;
        descText.text = newDescString;
        useButton.SetActive(isUsable);
    }

    public void ClearInventorySlots()
    {
        for(int i =0 ; i<inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();
            ClearInventorySlots();
            MakeInventorySlots();
            if (currentItem.itemNumber == 0)
            {
                SetTextAndButton("", false);

            }
        }
    }
}
