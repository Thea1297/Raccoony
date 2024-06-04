using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    [Header("Path")]
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;
    //part 34  21:00 explanation
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                myrb.MovePosition(temp);
                //ChangeState(EnemyState.walk);
                anim.SetBool("wakup", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) >roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);

                ChangeAnim(temp - transform.position);
                myrb.MovePosition(temp);
            }
            else
            {
                ChangePathGoal();
            }
        }
    }

    private void ChangePathGoal()
    {
        if(currentPoint== path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];

        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
