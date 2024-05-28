using UnityEngine;

public class HealingRune : Item
{
    [SerializeField] private int _amountOfHealth = 10;

    public override int PickUp()
    {
        base.PickUp();

        return _amountOfHealth;
    }
}
