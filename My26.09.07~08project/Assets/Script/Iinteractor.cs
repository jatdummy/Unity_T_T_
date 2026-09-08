using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iinteractor
{

    public GameObject GameObject { get; }
    public void TryInteract();
}

