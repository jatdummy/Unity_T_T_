using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    [SerializeField] private float _delay;
    private bool _isBool;
    private WaitForSeconds _wait;
    private Coroutine _routine;


    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }
    
    private void Start()
    {
        Debug.Log("Start ");
        
        Debug.Log("End ");
    }

    // 함수의 반환형은 'IEnumerator' , foreach문 활용가능..

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Run();
        if (Input.GetKeyDown(KeyCode.Alpha2)) Stop();
    }
    private void Run()
    {
        if (_routine != null) return;

        _routine = StartCoroutine(MyRoutine());
    }
    private void Stop()
    {
        if (_routine == null) return;

       StopCoroutine(_routine);
       _routine = null;
    }
    
    private IEnumerator MyRoutine()
    {
        while (true)
        {
            yield return _wait;
            // WaitUntil 괄호안의 조건이 참일 때까지 기다림.
            Debug.Log("Coroutine");
            // _isBool = false;
            // 이런 경우 garbage 쌓일 위험이 높음.
        }
        
        // 반환할 때는 'yield return'
        // yield return 000 : 000가 충족되는 상황까지 함수를 종료하고 대기할 것.

        // 루틴을 아예 멈출 때
        // yield break; return과 동일.
    }

}
