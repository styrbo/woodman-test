using System;
using System.Collections;
using UnityEngine;

public class WorkerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _deadDistance = 0.1f;

    public void SetDestination(Vector2 pos, Action endCallback = null)
    {
        StartCoroutine(Movement(pos, endCallback));
    }

    private IEnumerator Movement(Vector2 pos, Action endCallback = null)
    {
        while (Vector2.Distance(transform.position, pos) > _deadDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos, _speed * Time.deltaTime);
            yield return null;
        }
        
        endCallback?.Invoke();
    }
}