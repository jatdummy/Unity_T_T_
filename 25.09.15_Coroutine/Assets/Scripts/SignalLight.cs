using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalLight : MonoBehaviour
{
    [SerializeField] Renderer _renderer;
    private readonly WaitForSeconds _waitOneSecond = new WaitForSeconds(1f);
    private Coroutine _signalRoutine;
    private bool _isCrossRequsted;


    private void Awake()
    {
       _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        ReadInput();
    }

    private void Start()
    {
        
    }

    private void ReadInput()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_signalRoutine == null)
            {
                StartRoutine();
            }
            else
            {
                StopCoroutine(_signalRoutine);
                _signalRoutine = null;
            }

        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            _isCrossRequsted = true;
        }


    }

    private void StartRoutine()
    {
        _signalRoutine = StartCoroutine(RunSignalRoutine());
    }

    private IEnumerator RunSignalRoutine()
    {
        while (true)
        {
            _renderer.material.color = Color.red;
            Debug.Log($"SignalLight: 첫째 줄 {Time.time}");
            yield return _waitOneSecond;

            _renderer.material.color = Color.yellow;
            Debug.Log($"SignalLight: 둘째 줄 {Time.time}");
            yield return _waitOneSecond;
            yield return new WaitUntil(() => _isCrossRequsted);
            _isCrossRequsted = false;

            _renderer.material.color = Color.green;
            Debug.Log($"SignalLight: 둘째 줄 {Time.time}");
            yield return _waitOneSecond;

        }
    }
}
