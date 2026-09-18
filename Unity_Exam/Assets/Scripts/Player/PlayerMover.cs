using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string TAG_WALL = "Wall";

    [SerializeField] private float _meterPerSecond = 5f;

    private Rigidbody _body;
    private Vector3 _direction;

    private void Awake()
    {
        CacheComponents();
    }

    private void Update()
    {
        MoveByTransform();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAG_WALL))
        {
            Debug.Log("PlayerMover: 벽에 닿았습니다.");
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void CacheComponents()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void MoveByTransform()
    {
        // [BUG-02] 원인 : 곱해지는 방향의 길이가 둘 다 1 이 아님. / 수정 : _direction -> _direction.normalized
        transform.position += _direction.normalized * _meterPerSecond * Time.deltaTime;
    }// 
}
