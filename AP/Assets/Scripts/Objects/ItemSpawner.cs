using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, IItemSpawner
{
    [Header("ITEMS")]
    public List<GameObject> items = new ();

    public int countSpawn = 3;

    public Transform spawnSpot;

    [SerializeField]
    private Transform _itemsPoolsStorage;


    [Header("POOLS")]
    public int preloadCountItems = 10;
    [SerializeField]
    private ItemsPools ItemsPools;    

    private void Start()
    {
        InitPools();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            _ = ItemsPools.GetItem(spawnSpot, countSpawn);

        if (Input.GetKeyUp(KeyCode.R))
            _ = ReturnAllItemsToPool();

        if (Input.GetKeyUp(KeyCode.A))
            _ = Clear();
    }

    public async Task Clear()
    {
        await ItemsPools.ReturnAllItemstoPool();
    }

    public async Task ReturnAllItemsToPool()
    {
        await ItemsPools.ReturItemToPool();
    }

    public async Task GetItem()
    {
        await ItemsPools.ReturItemToPool();
    }

    public void InitPools()
    {
        for (int i = 0; items.Count > i; i++)
        {
            ItemsPools.Preload(items[i], _itemsPoolsStorage, preloadCountItems, i);
        }
    }
}
