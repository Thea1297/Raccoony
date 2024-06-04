using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Signals raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;
    public BoolValue storedOpen;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RuntimeValue;
        if (isOpen)
        {
            anim.SetBool("opened", true);
        }
    }

    // Update is called once per framee
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                //open the chest
                OpenChest();
            }
            else
            {
                //chest already open
                ChestUsed();
            }
        }
    }

    public void OpenChest()
    {
        dialogBox.SetActive(true); //activate window
        dialogText.text = contents.itemDesc; //put text
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents; //add contents to inventory
        raiseItem.Raise(); //raise the signal to player to animate
        context.Raise(); //raise the contextclue (the ? bubble)
        isOpen = true; //set chest to opened
        anim.SetBool("opened", true);
        storedOpen.RuntimeValue = isOpen;
    }

    public void ChestUsed()
    {
            dialogBox.SetActive(false);
            raiseItem.Raise();
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;

        }
    }
}
