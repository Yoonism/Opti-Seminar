using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _standbyPool = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _activePool = new List<GameObject>();

    private static PoolingManager instance = null;
    public static PoolingManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }


    public GameObject ActivateFromPool(GameObject newPrefab, Vector3 newPosition, Quaternion newRotation)
    {
        GameObject tempGameObject;

        if(_standbyPool.Count > 0)
        {
            tempGameObject = _standbyPool[0];
            tempGameObject.SetActive(true);
            tempGameObject.transform.position = newPosition;
            tempGameObject.transform.localRotation = newRotation;

            _standbyPool.RemoveAt(0);
        }
        else
        {
            tempGameObject = Instantiate(newPrefab, newPosition, newRotation);
        }

        _activePool.Add(tempGameObject);
        return tempGameObject;
    }

    public void StandbyToPool(GameObject targetGameObject)
    {
        targetGameObject.SetActive(false);
        _standbyPool.Add(targetGameObject);
        _activePool.Remove(targetGameObject);
    }
}
