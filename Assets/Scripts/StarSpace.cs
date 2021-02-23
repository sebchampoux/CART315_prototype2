using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpace : AbstractSpace
{
    [SerializeField] private int _numberOfStars = 1;
    [SerializeField] private int _costOfStars = 20;

    public override IEnumerator OnPlayerLand(GameObject player)
    {
        yield return null;
    }

    public override IEnumerator OnPlayerPass(GameObject player)
    {
        PlayerInventory pi = player.GetComponent<PlayerInventory>();
        if (pi.Coins >= _costOfStars)
        {
            BuyStar(pi);
        }
        else
        {
            Debug.Log("You're too poor to buy a star!  Come back later!");
        }
        yield return null;
    }

    private void BuyStar(PlayerInventory pi)
    {
        pi.RemoveCoins(_costOfStars);
        pi.AddStars(_numberOfStars);
        Debug.Log("You won a star!");
    }
}
