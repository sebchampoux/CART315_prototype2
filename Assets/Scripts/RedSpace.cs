using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpace : AbstractSpace
{
    [SerializeField] private int _coinsLostOnLand = 3;
    public static readonly float WAIT_TIME_ON_LAND = 1.0f;
    public override IEnumerator OnPlayerLand(PlayerInventory p)
    {
        p.RemoveCoins(_coinsLostOnLand);
        yield return new WaitForSeconds(WAIT_TIME_ON_LAND);
    }

    public override IEnumerator OnPlayerPass(PlayerInventory p)
    {
        yield return null;
    }
}
