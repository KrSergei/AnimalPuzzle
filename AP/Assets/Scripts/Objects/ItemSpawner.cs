using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, IItemSpawner
{
    [Header("ITEMS")]
    public List<GameObject> items = new ();

    public Transform spawnSpot;

    [SerializeField]
    private Transform _itemsPoolsStorage;    


    [Header("POOLS")]
    [SerializeField]
    private ItemsPools ItemsPools;

    private List<GameObject> _spawnedItems = new();

    private void Start()
    {
        for (int i = 0; items.Count > i; i++) 
        {
            //SetItem(items[i]);
            GameObject pool = Instantiate(gameObject, _itemsPoolsStorage);
            pool.name = items[i].name + "Pool";
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
        ItemsPools.Preload(item, _itemsPoolsStorage.transform);
    }
}
