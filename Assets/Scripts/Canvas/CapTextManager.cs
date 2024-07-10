using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//https://youtu.be/WfFDGpPy_7M?si=X2zO3bJ8VPlHdBO6
public class CapTextManager : MonoBehaviour
{

    public Inventory playerInventory;
    public TextMeshProUGUI capNumberDisplay; //number which is going to be changed in Cap script
    
    public void UpdateCapCount()
    {
        capNumberDisplay.text = "" + playerInventory.numOfCaps;
    }
}
