using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject InventoryCanvas;
    public InventoryItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
        ListItems();
    }



    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {

        foreach (Transform itemTransform in ItemContent)
        {
            Destroy(itemTransform.gameObject);
        }

        foreach (Item item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();

            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>();

            var removeButton = obj.transform.Find("RemoveItem").GetComponent<UnityEngine.UI.Button>();
            

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;    
        }

        SetInventoryItems();
    }

    public bool ShowHideCanvasAndReturnVisibility()
    {
        ListItems();
        if (InventoryCanvas.activeInHierarchy)
        {
            InventoryCanvas.SetActive(false);
            return false;
        }
        else
        {
            InventoryCanvas.SetActive(true);
            return true;
        }
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i = 0; i < items.Count; i++)
        {
            InventoryItems[i].AddItem(items[i]);
        }
    }


}
