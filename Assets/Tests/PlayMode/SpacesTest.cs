using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpacesTest
{
    public static GameObject CreateBlueSpace()
    {
        GameObject space = new GameObject();
        space.AddComponent<BlueSpace>();
        return space;
    }

    public static GameObject CreateRedSpace()
    {
        GameObject space = new GameObject();
        space.AddComponent<RedSpace>();
        return space;
    }

    [Test]
    public void TestBlueSpaceLand()
    {
        PlayerInventory i = PlayerInventoryTest.CreatePlayerInventory();
        GameObject blueSpace = CreateBlueSpace();
        blueSpace.GetComponent<AbstractSpace>().OnPlayerLand(i);
        Assert.AreEqual(i.Coins, 3);
    }

    [Test]
    public void TestRedSpaceLand()
    {
        PlayerInventory i1 = PlayerInventoryTest.CreatePlayerInventory();
        PlayerInventory i2 = PlayerInventoryTest.CreatePlayerInventory();
        i1.AddCoins(10);
        i2.AddCoins(2);

        GameObject redSpace = CreateRedSpace();
        redSpace.GetComponent<AbstractSpace>().OnPlayerLand(i1);
        redSpace.GetComponent<AbstractSpace>().OnPlayerLand(i2);

        Assert.AreEqual(i1.Coins, 7);
        Assert.AreEqual(i2.Coins, 0);
    }
}
