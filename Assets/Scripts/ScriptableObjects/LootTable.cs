using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Loot
{
    //hearts and caps are PowerUps
    public PowerUp thisLoot;
    public int lootChance;

}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loot;

    public PowerUp LootPowerUp()
    {
        //enemies contain this loottable and will draw a droprate from here
        //10:00 part 49
        int cumulativeProbability = 0;
        int currentProbability= Random.Range(0, 100);
        for(int i = 0;i<loot.Length; i++) {
            cumulativeProbability += loot[i].lootChance;
            if (currentProbability <= cumulativeProbability)
            {
                return loot[i].thisLoot;
            }
        
        }
        return null;
    }

}
