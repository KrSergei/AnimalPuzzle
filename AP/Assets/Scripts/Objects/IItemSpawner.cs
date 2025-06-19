using System.Threading.Tasks;
using UnityEngine;

public interface IItemSpawner 
{
    public void InitPools();

    public Task GetItem();

    public Task ReturnAllItemsToPool();

    public Task Clear();   
}
