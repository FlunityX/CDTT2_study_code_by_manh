using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool :MonoBehaviour
{
    [SerializeField] public Transform holder;
    [SerializeField] public List<GameObject> _objectPool;
    [SerializeField] public GameObject _objectToSpawn;


    [SerializeField]public int amountToSpawn;


    public virtual void Start()
    {
        GeneratePool();
    }
   
    

 

    public virtual void GeneratePool()
    {
        _objectPool = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToSpawn; i++)
        {
            tmp = Instantiate(_objectToSpawn, holder);
            tmp.SetActive(false);
            _objectPool.Add(tmp);
        }
    }
 

    public virtual GameObject GetObject()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            if (!_objectPool[i].activeInHierarchy)
            {
                return _objectPool[i];
            }
        }
        return null;
    }
}
