using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour, ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        Debug.Log("옵저버 등록");
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        Debug.Log("옵저버 해제");
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Notify();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        IObserver enemyObserver = other.GetComponent<IObserver>();
        if (enemyObserver != null)
        {
            RegisterObserver(enemyObserver);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Enemy"))
        {
            IObserver enemyObserver = other.GetComponent<IObserver>();
            if (enemyObserver != null)
            {
                RemoveObserver(enemyObserver);
            }
        }
    }
}
