using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpace : AbstractSpace
{
    [SerializeField] private int _coinsWonOnLand = 3;
    public static readonly float WAIT_TIME_ON_LAND = 2.0f;

    public override IEnumerator OnPlayerPass(GameObject player)
    {
        yield return null;
    }

    public override IEnumerator OnPlayerLand(GameObject player)
    {
        player.GetComponent<PlayerInventory>().AddCoins(_coinsWonOnLand);
        Debug.Log("You earned " + _coinsWonOnLand + " coins!");
        yield return new WaitForSeconds(WAIT_TIME_ON_LAND);
    }
}
