using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public event Action <Item> HaveTaken;

    public virtual int PickUp()
    {
        HaveTaken?.Invoke(this);

        return 0;
    }
}
