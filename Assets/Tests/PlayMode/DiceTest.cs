using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DiceTest
{
    public static GameObject CreateDie()
    {
        GameObject die = new GameObject();
        die.AddComponent<Dice>();
        return die;
    }

    [UnityTest]
    public IEnumerator TestDiceRoll()
    {
        GameObject die = CreateDie();
        Dice dc = die.GetComponent<Dice>();

        int[] values = new int[3];

        values[0] = dc.CurrentFaceNumber;
        dc.StartCoroutine(dc.RollDice());
        yield return new WaitForSeconds(dc.RollTime);
        values[1] = dc.CurrentFaceNumber;
        yield return new WaitForSeconds(dc.RollTime);
        values[2] = dc.CurrentFaceNumber;

        dc.StopAllCoroutines();

        Assert.AreNotEqual(values[0], values[1]);
        Assert.AreNotEqual(values[1], values[2]);

        yield break;
    }

    [UnityTest]
    public IEnumerator TestDiceStop()
    {
        GameObject die = CreateDie();
        Dice dc = die.GetComponent<Dice>();

        dc.StartCoroutine(dc.RollDice());
        yield return new WaitForSeconds(dc.RollTime);
        int valueBeforeStop = dc.CurrentFaceNumber;
        dc.HitDice();
        yield return new WaitForSeconds(1.0f);
        int valueAfterStop = dc.CurrentFaceNumber;

        Assert.AreEqual(valueBeforeStop, valueAfterStop);

        yield break;
    }
}
