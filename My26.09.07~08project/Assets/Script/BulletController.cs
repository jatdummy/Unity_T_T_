using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private int _damage;
    private float _speed;


    // 어딘가에 부딪히면
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player 인 경우 >> 데미지 추가
            Debug.Log("아야아야");
        }

        Destroy(gameObject);
    }

    private void Update() => Moveforward();

    // 앞으로 전진
    private void Moveforward()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
   
    // 터렛으로부터 데이터 전달 받기.
    public void SetData(int dagmage, float speed, float destroyDelay)
    {
        _damage = dagmage;
        _speed = speed;

        // 스폰 기준으로 제한시간 이후 파괴
        Destroy(gameObject, destroyDelay);
    }

}
