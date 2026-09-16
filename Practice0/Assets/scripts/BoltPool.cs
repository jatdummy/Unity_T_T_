using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BoltPool : MonoBehaviour
{
    [SerializeField] private GameObject _boltPrefab;
    [SerializeField] private int _poolSize = 8;

    private GameObject[] _bolts;
    private int _count;

    public static BoltPool Instance { get; private set; }

    private void Awake()
    {
        SetSingleton();
    }

    private void Start()
    {
        FillPool();
    }

    private void SetSingleton()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    private void FillPool()
    {
        _bolts = new GameObject[_poolSize];

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bolts = Instantiate(_boltPrefab);
            bolts.SetActive(false);

            _bolts[i] = bolts;
        }

        _count = _poolSize;
    }


    public GameObject Take()
    {
        if (_count > 0)
        {
            _count--;

            GameObject bolts = _bolts[_count];
            bolts.SetActive(true);

            return bolts;
        }
        
        Debug.Log("남은 총알이 없습니다.");
        
        return null;

    }

    public void Return(GameObject bolts)
    {
        bolts.SetActive(false);

        _bolts[_count] = bolts;
        _count++;
            
    }

}
