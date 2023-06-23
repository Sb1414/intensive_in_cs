namespace d06.Models;

public class Storage
{
    private int itemsInStorage;
    private readonly object lockObject = new object();

    public int ItemsInStorage
    {
        get { return itemsInStorage; }
        set { itemsInStorage = value; }
    }

    public bool IsEmpty => ItemsInStorage <= 0;

    public Storage(int totalItemCount)
    {
        ItemsInStorage = totalItemCount;
    }

    public bool TakeItemsFromStorage(int count)
    {
        lock (lockObject)
        {
            if (ItemsInStorage >= count)
            {
                ItemsInStorage -= count;
                return true;
            }

            return false;
        }
    }
}