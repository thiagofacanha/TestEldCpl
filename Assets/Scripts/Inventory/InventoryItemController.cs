using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;
    public Button RemoveButton;
   
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Instantiate(item.gameObjectToInstantiate,GameManager.instance.player.transform.position + GameManager.instance.player.transform.forward * 0.2f, GameManager.instance.player.transform.rotation);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}
