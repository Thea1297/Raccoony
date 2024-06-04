using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : PowerUp
{
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        powerupSignal.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.numOfCaps += 1;
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
