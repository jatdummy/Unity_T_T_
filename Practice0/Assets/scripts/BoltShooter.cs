using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoltShooter : MonoBehaviour
{

    private void Update()
    {
        ReadFireKey();
    }
    
    private void ReadFireKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bolts = BoltPool.Instance.Take();

        if(bolts == null)
        {
            return;
        }

        bolts.GetComponent<Bolt>().ResetState(transform.position);
    }
}
