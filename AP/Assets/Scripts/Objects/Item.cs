using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int _indexPool;

    public int IndexPool { get => _indexPool; set => _indexPool = value; }
}
