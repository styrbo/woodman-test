using System;
using System.Collections;
using Resources;
using UnityEngine;

public class WorkerMining : MonoBehaviour
{
    [SerializeField] private float _punchDelay;

    public void StartMining(ResourcesSource source, Action onTakeResource, Action endCallback = null)
    {
        StartCoroutine(Mining(source, onTakeResource, endCallback));
    }

    private IEnumerator Mining(ResourcesSource source, Action onTakeResource, Action endCallback = null)
    {
        while (source != null)
        {
            if (source.TryRequestResource() == false)
                break;

            onTakeResource.Invoke();
            
            yield return new WaitForSeconds(_punchDelay);
        }

        endCallback?.Invoke();
    }
}