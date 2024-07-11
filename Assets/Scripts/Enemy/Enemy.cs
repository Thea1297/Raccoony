using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//controls enemy
public enum EnemyState
{
    idle, 
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    //what every enemy has:
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public Vector2 homePosition;

    [Header("Death Effect")]
    public GameObject deathEffect;


    [Header("Death Signal")]
    public Signals roomSignal;

    [Header("Loot")]
    public LootTable thisLoot;

    private void Awake()
    {

        health = maxHealth.initialValue;
        
    }

    private void OnEnable()
    {
        transform.position = homePosition;
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }

    //how much damage is gonna take
    private void TakeDamage(float damage)
    {
        health-= damage;
        if(health<=0)
        {
            DeathEffect();
            MakeLoot();
            if (roomSignal != null)
            {


                roomSignal.Raise();
            }
            this.gameObject.SetActive(false); 
        }
    }

    private void MakeLoot()
    {
        //if loottable exists, create loottable
        if (thisLoot != null)
        {
            PowerUp current = thisLoot.LootPowerUp();
            if(current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    private void DeathEffect()
    {
        //adding animation for enemy death
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);

        }
    }

    public void Knock(Rigidbody2D myRb, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRb, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myrb, float knockTime)
    {
        if (myrb != null )
        {
            yield return new WaitForSeconds(knockTime);
            myrb.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myrb.velocity = Vector2.zero;
        }
    }

}
