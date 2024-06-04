using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    public Door[] doors;
    

    public void CheckEnemies()
    {
        //check if there are active enemies, if yes do nothing(return) or opendoors if no
        for(int i = 0; i<enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy && i < enemies.Length-1)
            {
                return;
            }

        }
        OpenDoors();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //set all enemies and pots active
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);

            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], true);
            }
            CloseDoors();
            virtualCamera.SetActive(true);
        }
        
    }

    public override void OnTriggerExit2D(Collider2D other)
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

    public void CloseDoors()
    {
        //go through doors in the list and set from open to close
        for(int i=0; i<doors.Length; i++)
        {
            doors[i].DoorClose();
        }
    }

    public void OpenDoors()
    { 
        //go through doors in the list and set from close to open
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].DoorOpen();
        }
    }
}
