using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://youtu.be/-vgNXo52y2A?si=NA-5AOYeQqFYuEWS
public class HeartContainer : PowerUp
{
    public FloatValue heartContainers;
    public FloatValue playerHealth;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            heartContainers.RuntimeValue += 1;
            playerHealth.RuntimeValue = heartContainers.RuntimeValue *2;
            powerupSignal.Raise();
            Destroy(this.gameObject);


        }
    }

}
