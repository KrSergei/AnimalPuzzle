using System.Collections.Generic;
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
            ItemsPools.GetItem(spawnSpot, countSpawn);
        if (Input.GetKeyUp(KeyCode.R))
            ItemsPools.ReturItemToPool();
        if (Input.GetKeyUp(KeyCode.A))
            Clear();
    }

    public void Clear()
    {
        ItemsPools.ReturnAllItemstoPool();
    }

    public GameObject GetItem()
    {
        throw new System.NotImplementedException();
    }

    public void SetItem(GameObject item)
    {
        throw new System.NotImplementedException();
    }

    public void InitPools()
    {
        for (int i = 0; items.Count > i; i++)
        {
            ItemsPools.Preload(items[i], _itemsPoolsStorage, preloadCountItems, i);
        }
    }
}
