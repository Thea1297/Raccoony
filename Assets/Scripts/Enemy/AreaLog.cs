using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLog : Log
{
    public Collider2D boundary; //area where they would roam
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius && boundary.bounds.Contains(target.transform.position) )
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                myrb.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakup", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius || !boundary.bounds.Contains(target.transform.position))
        {
            anim.SetBool("wakup", false);
        }
    }
}
