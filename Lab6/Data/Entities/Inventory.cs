namespace Lab6.Data.Entities;

public class Inventory
{
    public int InventoryItemId { get; set; }
    public int InventoryItemTypeId { get; set; }
    public string InventoryItemDescription { get; set; }

    public InventoryItemType InventoryItemType { get; set; }  // Foreign Key to InventoryItemType
}
