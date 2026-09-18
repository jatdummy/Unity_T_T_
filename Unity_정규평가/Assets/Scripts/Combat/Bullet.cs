using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _shootPower = 600f;
    [SerializeField] private float _lifeSeconds = 1.5f;

    private Rigidbody _body;
    private float _elapsed;

    private void Awake()
    {
        CacheComponents();
    }

    private void Update()
    {
        CountLifeTime();
    }

    public void Launch(Vector3 startPosition, Vector3 direction)
    {
        transform.position = startPosition;
        _elapsed = 0f;
        _body.AddForce(direction * _shootPower);
    }

    private void CacheComponents()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void CountLifeTime()
    {
        _elapsed += Time.deltaTime;

        if (_elapsed < _lifeSeconds)
        {
            return;
        }

        // [BUG-10] 원인 : 속도 초기화를 안해주고 꺼내고 있었음 / 수정 :_body.velocity = Vector3.zero; 추가.
        _body.velocity = Vector3.zero;
        BulletPool.Instance.Return(gameObject);
    }
}
