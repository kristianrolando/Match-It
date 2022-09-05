using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Object : MonoBehaviour, IClick
{
    public int index;
    public virtual int Click()
    {
        return index;
    }
}
