using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpace : AbstractSpace
{
    [SerializeField] private int _numberOfStars = 1;
    [SerializeField] private int _costOfStars = 20;
    public override IEnumerator OnPlayerLand(PlayerInventory p)
    {
        yield return null;
    }

    public override IEnumerator OnPlayerPass(PlayerInventory p)
    {
        yield return null;
        // Prompt for star
        // If yes, add star to count
        // Then change star space location
    }
}
