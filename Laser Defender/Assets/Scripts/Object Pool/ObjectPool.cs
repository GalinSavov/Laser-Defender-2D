using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int poolSize = 10;
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject enemyPrefab = null;
    private Dictionary<ProjectileType,Stack<GameObject>> dictionary = new Dictionary<ProjectileType,Stack<GameObject>>();
    private void Awake()
    {
        InitializePool(ProjectileType.Player,playerPrefab);
        InitializePool(ProjectileType.Enemy,enemyPrefab);
        DontDestroyOnLoad(gameObject);
    }
    public void InitializePool(ProjectileType key,GameObject prefab)
    {
        dictionary.Add(key, new Stack<GameObject>());
        for(int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(prefab,transform);
            dictionary[key].Push(instance);
            instance.SetActive(false);
        }
    }
    public IEnumerator ReturnToPool(GameObject instance,ProjectileType key,float duration)
    {
        yield return new WaitForSeconds(duration);
        instance.SetActive(false);
        dictionary[key].Push(instance);
    }
    public GameObject GetObject(ProjectileType key)
    {
        if (dictionary[key].Count > 0)
        {
            GameObject instance = dictionary[key].Pop();
            instance.SetActive(true);
            return instance;
        }
        return null;
    }
}
