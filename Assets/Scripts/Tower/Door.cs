using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key, enemy, button
}
public class Door : Interactable
{
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                //if a player has a key, call DoorOpen() and remove one key from inventory
                if (playerInventory.numOfKeys > 0)
                {
                    playerInventory.numOfKeys--;
                    DoorOpen();
                }
            }
        }
    }

    public void DoorOpen()
    {
        //turn off the door's sprite renderer, set open to true, turn off box collider
        spriteRenderer.enabled = false;
        open = true;
        boxCollider.enabled = false;
    }
    public void DoorClose()
    {
        spriteRenderer.enabled = true;
        open = false;
        boxCollider.enabled = true;
    }
}
