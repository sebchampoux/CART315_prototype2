using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpace : AbstractSpace
{
    // Commenté temporairement pour qu'il arrête de chialer -_-
    //[SerializeField] private int _numberOfStars = 1;
    //[SerializeField] private int _costOfStars = 20;

    public override IEnumerator OnPlayerLand(GameObject player)
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator OnPlayerPass(GameObject player)
    {
        throw new System.NotImplementedException();
    }
}
