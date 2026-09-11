using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour, Iinteractable
{
    public GameObject GameObject { get => gameObject; }
    private Outline _outline;

    private void Awake() => CacheComponents();
    private void Start() => Init();

    public void Targeting()
    {
        _outline.enabled = true;
    }

    public void Untargeting()
    {
        _outline.enabled = false;
    }


    public void Interact(Iinteractor owner)
    {
        // if (!(owner is PlayerController)) return;

        // PlayerController player = (PlayerController)owner;
        // 이동속도 변화 ()

        Destroy(GameObject);
    }
    private void Init()
    {
        _outline.enabled = false;
    }

    private void CacheComponents()
    {
        _outline = gameObject.GetComponent<Outline>();
    }
}
