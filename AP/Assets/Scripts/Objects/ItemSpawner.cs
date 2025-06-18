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

    private List<GameObject> _spawnedItems = new();

    private void Start()
    {
        InitPools();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            ItemsPools.GetItem(GetRandom(), spawnSpot, countSpawn);
    }

    private int GetRandom()
    {
        return Random.Range(0, items.Count);
    }

    private void InitPools()
    {
        for (int i = 0; items.Count > i; i++)
        {
            //SetItem(items[i]);
            ItemsPools.Preload(items[i], _itemsPoolsStorage, preloadCountItems, i);
        }
    }

    public void Clear()
    {
        throw new System.NotImplementedException();
    }

    public GameObject GetItem()
    {
        throw new System.NotImplementedException();
    }

    public void SetItem(GameObject item)
    {
        throw new System.NotImplementedException();
    }
}
