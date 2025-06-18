using UnityEngine;

public class ItemsPools : MonoBehaviour
{
    public void Preload(GameObject item, Transform storage)
    {
        GameObject pool = Instantiate(gameObject, storage);
        pool.name = item.name + "Pool";
    }
}
