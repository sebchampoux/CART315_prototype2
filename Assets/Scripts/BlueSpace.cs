using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpace : AbstractSpace
{
    [SerializeField] private int _coinsWonOnLand = 3;
    public static readonly float WAIT_TIME_ON_LAND = 2.0f;

    public override IEnumerator OnPlayerLand(PlayerInventory p)
    {
        p.AddCoins(_coinsWonOnLand);
        yield return new WaitForSeconds(WAIT_TIME_ON_LAND);
    }

    public override IEnumerator OnPlayerPass(PlayerInventory p)
    {
        yield return null;
    }
}
