using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpace : AbstractSpace
{
    // Comment� temporairement pour qu'il arr�te de chialer -_-
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
