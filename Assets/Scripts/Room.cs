using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies; //for kill all in room purposes but i removed it
    public Pot[] pots;

    [Header("Cinemachine")]
    public GameObject virtualCamera;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //set all enemies and pots active
            for(int i=0; i< enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);

            }
            for(int i=0; i< pots.Length; i++)
            {
                ChangeActivation(pots[i], true);
            }
            virtualCamera.SetActive(true);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //set all enemies and pots inactive
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);

            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], false);
            }
            virtualCamera.SetActive(false);
        }
    }

    public void OnDisable()
    {
        virtualCamera.SetActive(false);
    }

   public void ChangeActivation(Component comp, bool activation)
    {
        comp.gameObject.SetActive(activation);
    }
}
