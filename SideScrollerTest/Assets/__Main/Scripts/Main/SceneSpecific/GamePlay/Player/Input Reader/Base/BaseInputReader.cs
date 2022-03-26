using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInputReader : MonoBehaviour
{
    public virtual void Init()
    {
        Debug.Log("Input Reader Initiated");
    }
}
