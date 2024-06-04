using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger, 
    idle
}
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public PlayerState currentState;
    public float speed; //speed of character
    private Rigidbody2D myRigidbody;
    private Vector3 change;

    [Header("Movement animations")]
    private Animator animator;

    [Header("Health")]
    public FloatValue currentHealth;
    public Signals playerHealthSignal;

    [Header("Scene Transition")]
    public VectorValue startingPosition;

    [Header("Receive Item")]
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody=GetComponent<Rigidbody2D>();

        //at start all 4 hitboxes active, this fixes it - at start set players position to this
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);

        //start position when scene transition
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {   
        //player interaction
        if(currentState == PlayerState.interact) 
        {
            return;
        }

        //movement
        change= Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState!= PlayerState.attack && currentState!=PlayerState.stagger)
        {
            StartCoroutine(attackCo());
        }
        else if (currentState == PlayerState.walk || currentState==PlayerState.idle)
        {
          UpdateAnimAndMove();
        }

    }

    private IEnumerator attackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);

        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    public void RaiseItem()
    {
        if (playerInventory.currentItem != null )
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("receiveItem", true);
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("receiveItem", false);
                currentState = PlayerState.idle;
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }

    void UpdateAnimAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        change.Normalize();
        //move players rb to the position we want to change (change)
        myRigidbody.MovePosition(transform.position+change*speed*Time.deltaTime);
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue> 0)
        {
            
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState= PlayerState.idle;
            myRigidbody.velocity=Vector2.zero;
        }
    }

}
