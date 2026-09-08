using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iinteractable
{

    public GameObject GameObject { get; }

    public void Targeting();
    public void Untargeting();

    public void Interact(Iinteractor owner);
}

