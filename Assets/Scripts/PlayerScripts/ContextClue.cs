using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{   
    public GameObject contextClue; //reference to contextClue object attached to Player
    public bool contextActive=false;
    
    public void ChangeContext()
    {
        contextActive =! contextActive;
        if(contextActive )
        {
            contextClue.SetActive(true);
        }
        else
        {
            contextClue.SetActive(false);
        }
    }

}
