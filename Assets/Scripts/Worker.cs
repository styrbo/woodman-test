using Resources;
using UnityEngine;
using Zenject;

public class Worker : MonoBehaviour
{
    [Inject] private WorkerMovement _movement;
    [Inject] private WorkerInventory _inventory;
    [Inject] private WorkerMining _mining;
    [Inject] private House _house;

    private void Start()
    {
        SelectNewTarget();
    }

    private void SelectNewTarget()
    {
        if (Map.TryGetNearest(transform.position, out var source))
        {
            _movement.SetDestination(source.transform.position, () =>
                {
                    _mining.StartMining(source, () =>
                        {
                            _inventory.TryAddItem(source.ResourceType);
                        }, () =>
                        {
                            _movement.SetDestination(_house.transform.position, () =>
                            {
                                _inventory.Clear();
                                SelectNewTarget(); 
                            });
                        });
                });
            return;
        }

        Map.OnResourcesCreated += WaitForNewResources;
    }

    private void WaitForNewResources()
    {
        SelectNewTarget();
        Map.OnResourcesCreated -= WaitForNewResources;
    }
}