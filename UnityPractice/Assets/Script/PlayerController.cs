using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour, Iinteractor
{
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private float _detectionRange;
    [SerializeField] private KeyCode _interactionKey = KeyCode.E;
    private PlayerWeapon _weapon;
    private PlayerMovement _movement;
    private Transform _cameraTransform;

    private Iinteractable _targetInteractable;

    private bool _hasDetectInteractable => _targetInteractable != null;
    private bool _isPressedInteractionKey => Input.GetKeyDown(_interactionKey);
    private bool _canInteraction => _hasDetectInteractable && _isPressedInteractionKey;

    public GameObject GameObject { get => gameObject; }


    // --------------------------------------
    private void Awake() => CacheComponents();
    private void Start() => LockCursor();
    private void FixedUpdate() => _movement.Move();
    
    private void Update()
    {
        if (!GameManager.Instance.IsGameRunning) return;

        _movement.Rotate();
        _weapon.Fire();
        _weapon.Reload();
        DetectInteractable();
        TryInteract();

        if (Input.GetKeyDown(KeyCode.P)) GameManager.Instance.Pause();
        else if (Input.GetKeyDown(KeyCode.O)) GameManager.Instance.Run();
    }
    private void LateUpdate()
    {
        SetWeaponTransform();
        SetCameraTransform();
    }

    // --------------------------------------

    private void CacheComponents()
    {
        _movement = GetComponent<PlayerMovement>();
        _weapon = GetComponentInChildren<PlayerWeapon>();
        _cameraTransform = Camera.main.transform;

    }
    // 마우스 커서 락.
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void SetWeaponTransform()
    {
        _weapon.transform. SetPositionAndRotation(
            _cameraPivot.position,
            _cameraPivot.rotation)
            ;
    }

    private void SetCameraTransform()
    {

        _cameraTransform.SetPositionAndRotation(
            _cameraPivot.position,
            _cameraPivot.rotation
            );
    }


    public void DetectInteractable()
    {
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, _detectionRange))
        {

            if (_hasDetectInteractable)
            {
                _targetInteractable.Untargeting();
                _targetInteractable = null;
            }
            
            return;
        }

        if (_hasDetectInteractable)
        {
            if(hit.collider.gameObject == _targetInteractable.GameObject)
            {
                return; // 같은 Interactable을 계속 주시하는 경우
            }
        }

        _targetInteractable?.Untargeting();
        _targetInteractable = hit.collider.GetComponent<Iinteractable>();

        _targetInteractable?.Targeting();
    }

    public void TryInteract()
    {
        if (!_canInteraction) return;

        _targetInteractable.Interact(this);
        _targetInteractable = null;
    }

}
