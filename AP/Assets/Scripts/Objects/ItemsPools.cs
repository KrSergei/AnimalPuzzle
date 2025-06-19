using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPools : MonoBehaviour
{
    [SerializeField]
    private Dictionary<int, Queue<GameObject>> _pools = new ();

    [SerializeField] private float _timeBetweenSpawnItems = 2f;

    [SerializeField]
    private Queue<GameObject> _spawnedItems = new();

    [SerializeField]
    private Transform poolSpawnedItems;

    public void Preload(GameObject item, Transform storage, int count, int indexPool)
    { 
        var pool = new GameObject(item.name);

        Queue<GameObject> items = new ();

        pool.transform.parent = storage;

        for (int i = 0; i < count; i++) 
        {
            var currentItem = Instantiate(item, pool.transform);
            currentItem.GetComponent<Item>().IndexPool = indexPool;
            items.Enqueue(currentItem);
            currentItem.SetActive(false);
        }
        _pools.Add(indexPool, items);

    }

    /// <summary>
    /// Создание объекта в точке появления объекта, добавление в коллекцию "очередь" сгенерированных объектов
    /// </summary>
    /// <param name="spawnSpot"></param>
    /// <param name="count"></param>
    public async void GetItem(Transform spawnSpot, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = GetRandom(_pools.Count);
            _pools.TryGetValue(index, out var pool);
            var item = pool.Dequeue();
            item.transform.position = spawnSpot.position;
            item.transform.parent = poolSpawnedItems;
            item.SetActive(true);            
            _spawnedItems.Enqueue(item);            
            await UniTask.Delay(System.TimeSpan.FromSeconds(_timeBetweenSpawnItems));
        }
    }

    public async void ReturItemToPool()
    {
        if(_spawnedItems.Count > 0)
        {
            GameObject item = _spawnedItems.Dequeue();
            int indexPool = item.GetComponent<Item>().IndexPool;
            _pools.TryGetValue(item.GetComponent<Item>().IndexPool, out var pool);
            pool.Enqueue(item);
            item.SetActive(false);
            item.transform.parent = transform.GetChild(indexPool);
        }        
        await UniTask.CompletedTask;
    }

    public async void ReturnAllItemstoPool()
    {
        if (_spawnedItems.Count > 0)
        {  
            while (_spawnedItems.Count > 0)
            {          
                GameObject item = _spawnedItems.Dequeue();
                int indexPool = item.GetComponent<Item>().IndexPool;
                _pools.TryGetValue(indexPool, out var pool);
                pool.Enqueue(item);
                item.transform.parent = transform.GetChild(indexPool);
                item.SetActive(false);
            } 
        }
        await UniTask.CompletedTask;
    }

    private int GetRandom(int countPools)
    {
        return Random.Range(0, countPools);
    }
}
