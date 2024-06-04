using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            AddItemToInventory();
            Destroy(this.gameObject); //you can also make it inactive instead
        }
    }

    void AddItemToInventory()
    {
        if (playerInventory && thisItem)
        {
            if(playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.itemNumber += 1;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.itemNumber += 1;
            }
        }
    }
}
