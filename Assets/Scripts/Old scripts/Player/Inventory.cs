using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int _money = 0;

    public void GetMoney(int countMoney)
    {
        _money += countMoney;
    }
}
