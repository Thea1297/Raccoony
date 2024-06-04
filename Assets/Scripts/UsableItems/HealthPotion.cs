using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
   public FloatValue playerHealth;
    public Signals healthSignal;
    public void Use(int amountToIncrease)
    {
        playerHealth.RuntimeValue += amountToIncrease;
        healthSignal.Raise();
    }
}
