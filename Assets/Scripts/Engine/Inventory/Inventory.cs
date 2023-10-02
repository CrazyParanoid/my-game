using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Slot> inventorySlots;

    public void AddItem(DropItem drop)
    {
        var freeSlot = inventorySlots.Find(item => !item.HasItem());

        var gameItem = new GameObject("Item");
        gameItem.AddComponent<SlotItem>();
        gameItem.transform.parent = freeSlot.transform;

        var inventoryItem = gameItem.GetComponent<SlotItem>();
        inventoryItem.AddItem((Item)drop.Item, drop.ImageSprite);

        drop.gameObject.SetActive(false);
        Destroy(drop);
    }

    void Start()
    {
        inventorySlots = GetComponentsInChildren<Slot>().ToList();
    }
}
