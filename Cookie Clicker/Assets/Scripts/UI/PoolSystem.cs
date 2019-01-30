using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolSystem : MonoBehaviour
{

    private Dictionary<int, Queue<GameObject>> _poolDictionary = new Dictionary<int, Queue<GameObject>>();

    public static PoolSystem Instance;

    //Make sure there's only one PoolSystem (singleton)
    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void CreatePool(GameObject prefab, int poolSize, Transform parent)
    {
        int poolKey = prefab.GetInstanceID();

        //If the key to be insered is new on the dictionary
        if (!_poolDictionary.ContainsKey(poolKey))
        {
            _poolDictionary.Add(poolKey, new Queue<GameObject>());

            for (int i = 0; i < poolSize; i++)
            {
                GameObject newObject = Instantiate(prefab, parent);//Creates new object
                newObject.SetActive(false);//Deactivate object
                _poolDictionary[poolKey].Enqueue(newObject);//Adds the object on the dictionary with the right key
            }
        }
    }

    public GameObject ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
    {
        int poolKey = prefab.GetInstanceID();
        if (_poolDictionary.ContainsKey(poolKey))
        {
            GameObject objectToReuse = _poolDictionary[poolKey].Dequeue();//Removes the first object on the dictionary
            _poolDictionary[poolKey].Enqueue(objectToReuse);//Places the object on the last position of the dictionary

            //Enables the object and set its position/rotation
            objectToReuse.SetActive(true);
            objectToReuse.transform.SetParent(parent);
            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;

            return objectToReuse;
        }
        return null;
    }


    public void AddPoolSize(GameObject prefab, int numberAddedToPoolSize)
    {
        int poolKey = prefab.GetInstanceID();

        if (_poolDictionary.ContainsKey(poolKey))
        {
            for (int i = 0; i < numberAddedToPoolSize; i++)
            {
                GameObject newObject = Instantiate(prefab) as GameObject;//Creates new Object
                newObject.SetActive(false);//Deactivate object
                _poolDictionary[poolKey].Enqueue(newObject);//Adds the object on the dictionary with the right key
            }
        }
    }
}
