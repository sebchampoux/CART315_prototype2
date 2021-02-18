using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpace : AbstractSpace
{
    [SerializeField] private int _coinsWonOnLand = 3;

    public override void OnPlayerLand(PlayerInventory p)
    {
        p.AddCoins(_coinsWonOnLand);
    }

    public override void OnPlayerPass(PlayerInventory p)
    {
        // Does nothing
    }
}
