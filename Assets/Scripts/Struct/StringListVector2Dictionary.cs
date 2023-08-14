using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Entry
{
    public string Key;
    public List<Vector2> Value;
}

[Serializable]
public class StringListVector2Dictionary
{
    [SerializeField] private List<Entry> entries;

    public List<Entry> Entries
    {
        get { return entries; }
        set { entries = value; }
    }

    public StringListVector2Dictionary()
    {
        entries = new List<Entry>();
    }

    public List<Vector2> this[string key]
    {
        get
        {
            int index = FindIndex(key);
            if (index != -1)
            {
                return entries[index].Value;
            }

            return null;
        }
        set
        {
            int index = FindIndex(key);
            if (index != -1)
            {
                entries[index].Value = value;
            }
            else
            {
                entries.Add(new Entry { Key = key, Value = value });
            }
        }
    }

    private int FindIndex(string key)
    {
        for (int i = 0; i < entries.Count; i++)
        {
            if (entries[i].Key.Equals(key))
            {
                return i;
            }
        }

        return -1;
    }

    // Add, Remove, ContainsKey 함수 추가
    public void Add(string key, List<Vector2> value)
    {
        int index = FindIndex(key);
        if (index == -1)
        {
            entries.Add(new Entry { Key = key, Value = value });
        }
        else
        {
            Debug.LogWarning("Key already exists.");
        }
    }

    public bool Remove(string key)
    {
        int index = FindIndex(key);
        if (index != -1)
        {
            entries.RemoveAt(index);
            return true;
        }

        return false;
    }

    public bool ContainsKey(string key)
    {
        return FindIndex(key) != -1;
    }

    // 딕셔너리 처럼 사용할 수 있는 다른 함수들도 위와 같이 구현할 수 있습니다.
}

[Serializable]
public class GameObjectEntry
{
    public string Key;
    public GameObject Value;
}

[Serializable]
public class StringGameObjectDictionary
{
    [SerializeField] private List<GameObjectEntry> entries;

    public List<GameObjectEntry> Entries
    {
        get { return entries; }
        set { entries = value; }
    }

    public StringGameObjectDictionary()
    {
        entries = new List<GameObjectEntry>();
    }

    public GameObject this[string key]
    {
        get
        {
            int index = FindIndex(key);
            if (index != -1)
            {
                return entries[index].Value;
            }

            return null;
        }
        set
        {
            int index = FindIndex(key);
            if (index != -1)
            {
                entries[index].Value = value;
            }
            else
            {
                entries.Add(new GameObjectEntry { Key = key, Value = value });
            }
        }
    }

    private int FindIndex(string key)
    {
        for (int i = 0; i < entries.Count; i++)
        {
            if (entries[i].Key.Equals(key))
            {
                return i;
            }
        }

        return -1;
    }

    // Add, Remove, ContainsKey 함수 추가
    public void Add(string key, GameObject value)
    {
        int index = FindIndex(key);
        if (index == -1)
        {
            entries.Add(new GameObjectEntry { Key = key, Value = value });
        }
        else
        {
            Debug.LogWarning("Key already exists.");
        }
    }

    public bool Remove(string key)
    {
        int index = FindIndex(key);
        if (index != -1)
        {
            entries.RemoveAt(index);
            return true;
        }

        return false;
    }

    public bool ContainsKey(string key)
    {
        return FindIndex(key) != -1;
    }

    // 딕셔너리 처럼 사용할 수 있는 다른 함수들도 위와 같이 구현할 수 있습니다.
}
