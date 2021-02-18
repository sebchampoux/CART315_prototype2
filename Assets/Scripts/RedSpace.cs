using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpace : AbstractSpace
{
    [SerializeField] private int _coinsLostOnLand = 3;
    public override void OnPlayerLand(PlayerInventory p)
    {
        p.RemoveCoins(_coinsLostOnLand);
    }

    public override void OnPlayerPass(PlayerInventory p)
    {
        // Do nothing
    }
}
