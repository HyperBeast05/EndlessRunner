using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PoolItems
{
    public GameObject itemPrefab;
    public int count;
    public bool isExpandable;
}

public class PlatformPool : Singleton<PlatformPool>
{

    [SerializeField] private List<PoolItems> m_items;
    [SerializeField] private List<GameObject> m_platformPool;

    protected override void Awake()
    {
        base.Awake();
       foreach (PoolItems obj in m_items)
        {
            for (int i = 0; i < obj.count; i++)
            {
                GameObject newPlatform = Instantiate(obj.itemPrefab);
                newPlatform.SetActive(false);
                m_platformPool.Add(newPlatform);
            }
        }
    }

    public GameObject GetPlatform()
    {
        Utils.Shuffle(m_platformPool);
        for (int i = 0; i < m_platformPool.Count; i++)
        {
            if (!m_platformPool[i].activeInHierarchy)
            {
                return m_platformPool[i];
            }
        }

        foreach (PoolItems obj in m_items)
        {
            if (obj.isExpandable)
            {
                GameObject newPlatform = Instantiate(obj.itemPrefab);
                newPlatform.SetActive(false);
                m_platformPool.Add(newPlatform);
                return newPlatform;
            }
        }
        return null;
    }
        
}

public static class Utils
{
    public static System.Random r = new System.Random();
    public static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = r.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}