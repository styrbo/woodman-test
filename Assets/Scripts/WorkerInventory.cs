using System;
using Resources;
using UnityEngine;

public class WorkerInventory : MonoBehaviour
{
    [SerializeField] private GameObject[] _backpackPrefab;
    [SerializeField] private uint _maxItems;

    private uint _itemsCount;

    public uint ItemsCount
    {
        get => _itemsCount;
        private set
        {
            for (var i = 0; i < _backpackPrefab.Length; i++)
            {
                _backpackPrefab[i].SetActive(i < value);
            }

            _itemsCount = value;
        }
    }

    private void Start()
    {
        ItemsCount = 0;
    }

    public bool TryAddItem(Resource resource)
    {
        if (ItemsCount >= _maxItems)
            return false;
        
        ItemsCount++;
        
        return true;
    }

    public void Clear()
    {
        ItemsCount = 0;
    }
}