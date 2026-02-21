class InventoryService
{
    private string[,] inventory = new string[2, 3];
    private string[] initialStock = { "10", "5", "20" };

    public InventoryService()
    {
        ResetToInitial();
    }

    public string[,] GetProducts()
    {
        return inventory;
    }

    public void UpdateStock(int index, string qty)
    {
        inventory[1, index] = qty;
    }

    public void ResetToInitial()
    {
        inventory[0, 0] = "Apples";
        inventory[0, 1] = "Milk";
        inventory[0, 2] = "Bread";

        for (int i = 0; i < initialStock.Length; i++)
        {
            inventory[1, i] = initialStock[i];
        }
    }
}
