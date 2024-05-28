using UnityEngine;

public class Coin : Item 
{
    [SerializeField] private int _reward = 1;

    public override int PickUp()
    {
        base.PickUp();

        return _reward;
    }
}
