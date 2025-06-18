using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPools : MonoBehaviour
{
    [SerializeField]
    private Dictionary<int, Queue<GameObject>> _pools = new ();

    [SerializeField] private float _timeBetweenSpawnItems = 2f;

    public void Preload(GameObject item, Transform storage, int count, int indexPool)
    { 
        var pool = new GameObject(item.name);

        Queue<GameObject> items = new ();

        pool.transform.parent = storage;

        for (int i = 0; i < count; i++) 
        {
            var currentItem = Instantiate(item, pool.transform);
            items.Enqueue(currentItem);
            currentItem.SetActive(false);
        }
        _pools.Add(indexPool, items);
    }

    public async void GetItem(int itemIndex, Transform spawnSpot, int count)
    {
        for (int i = 1; i < count; i++)
        {
            _pools.TryGetValue(itemIndex, out var pool);
            var item = pool.Dequeue();
            item.transform.position = spawnSpot.position;
            item.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(_timeBetweenSpawnItems));
        }
    }
}
