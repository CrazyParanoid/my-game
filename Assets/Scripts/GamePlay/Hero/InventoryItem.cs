using UnityEngine;

public class InventoryItem
{
    [SerializeField]
    private Item item;

    [SerializeField]
    private int count;

    public InventoryItem(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public void IncreaseCount(int value)
    {
        count += value;
    }

    public int Count
    {
        get { return count; }
    }

    public Item Item { 
        get { return item; } 
    }
}
