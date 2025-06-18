using UnityEngine;

public interface IItemSpawner 
{
    public GameObject GetItem();

    public void SetItem(GameObject item);

    public void Clear();   
}
