using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CapTextManager : MonoBehaviour
{

    public Inventory playerInventory;
    public TextMeshProUGUI capNumberDisplay; 
    
    public void UpdateCapCount()
    {
        capNumberDisplay.text = "" + playerInventory.numOfCaps;
    }
}
