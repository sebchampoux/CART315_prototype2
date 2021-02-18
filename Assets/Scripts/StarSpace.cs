using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpace : AbstractSpace
{
    [SerializeField] private int _numberOfStars = 1;
    [SerializeField] private int _costOfStars = 20;
    public override void OnPlayerLand(PlayerInventory p)
    {
        // Do nothing
    }

    public override void OnPlayerPass(PlayerInventory p)
    {
        // Prompt for star
        // If yes, add star to count
        // Then change star space location
    }
}
