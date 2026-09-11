using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _cooldown;
    [SerializeField] private Transform _headTransform;
    [SerializeField] private Transform _muzzlelPoint;
    [Header("Bullet")]
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _returnDelay;


    private float _currentCooldown;
    private Transform _playerTransform;
    private bool _isPlayerInTrigger { get { return _playerTransform != null; } }
    private bool _isPlayerInSight = false;
    private bool _isReadyToFire { get { return _currentCooldown >= _cooldown; } }
    private SphereCollider _sphereCollider;

    private void Awake() => CacheComponents();

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            _playerTransform = other.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerTransform = null;
        }
    }

    private void Update()
    {
        UpdateCurrentCooldown();
        RayShotToPlayer();
        Rotate();
        FIre();
    }

    private void CacheComponents()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void FIre()
    {
        if (!_isPlayerInSight || !_isPlayerInTrigger) return;

        Vector3 look = new Vector3(
            _playerTransform.position.x,
            _headTransform.position.y,
            _playerTransform.position.z
            );

        _headTransform.LookAt(_playerTransform.position);


        if (!_isReadyToFire) return;

        SpawnBullet();
        Debug.Log("두두두두");
        
        _currentCooldown = 0f;


    }

    private void UpdateCurrentCooldown()
    {
        if (_isReadyToFire) return;
        _currentCooldown += Time.deltaTime;

    }


    private void Rotate()
    {
        if (_isPlayerInSight) return;

        _headTransform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    
    }


    private void SpawnBullet()
    {
        // 1. 얻어오기.
        IPoolable bullet = _bulletPool.Take();

        // 2. Transform.position, rotation 설정.
        bullet.tr.position = _muzzlelPoint.position;
        bullet.tr.rotation = _muzzlelPoint.rotation;

        // 3. 활성화
        bullet.tr.gameObject.SetActive(true);
        
        
        /* 프리팹, Instantiate 하면서 position, rotation 설정.
        BulletController bullet = Instantiate(
            bulletPrefab,
            _muzzlelPoint.position,
            _muzzlelPoint.rotation
            );
        */

        (bullet as BulletController).SetData(_bulletDamage, _bulletSpeed, _returnDelay);
  
    }


    private void RayShotToPlayer()
    {
        _isPlayerInSight = false;
        if (!_isPlayerInTrigger) return;


        Vector3 from = new Vector3(
            transform.position.x,
            transform.position.y + _muzzlelPoint.position.y / 2,
            transform.position.z
            );

        Vector3 to = new Vector3(
            _playerTransform.position.x,
            _playerTransform.position.y + _muzzlelPoint.position.y / 2,
            _playerTransform.position.z
            );

        Ray ray = new Ray(from, (to - from).normalized);
        RaycastHit hit;
        
        // 1. LayerMask 배운 후 고치기
        // 2. 발사 높이와 감지 높이 다르게 
        // 3. RaycastAll로 배열에 모두 담아 처리.


        if (Physics.Raycast(ray, out hit, _sphereCollider.radius))
        {
            if (hit.transform.CompareTag("Player"))
            {
                _isPlayerInSight = true;
                Debug.Log("플레이어 찾았다");
            }
        }
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position * 5, transform.forward * 4);
    }
    */
}
