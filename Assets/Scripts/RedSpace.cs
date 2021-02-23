using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpace : AbstractSpace
{
    [SerializeField] private int _coinsLostOnLand = 3;
    public static readonly float WAIT_TIME_ON_LAND = 1.0f;

    public override IEnumerator OnPlayerPass(GameObject player)
    {
        yield return null;
    }

    public override IEnumerator OnPlayerLand(GameObject player)
    {
        player.GetComponent<PlayerInventory>().RemoveCoins(_coinsLostOnLand);
        yield return new WaitForSeconds(WAIT_TIME_ON_LAND);
    }
}
