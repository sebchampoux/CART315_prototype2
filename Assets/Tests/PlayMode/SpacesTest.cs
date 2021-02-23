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

        AbstractSpace blueSpaceComponent = blueSpace.GetComponent<AbstractSpace>();
        blueSpaceComponent.StartCoroutine(blueSpaceComponent.OnPlayerLand(i));
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
        AbstractSpace redSpaceComponent = redSpace.GetComponent<AbstractSpace>();
        redSpaceComponent.StartCoroutine(redSpaceComponent.OnPlayerLand(i1));
        redSpaceComponent.StartCoroutine(redSpaceComponent.OnPlayerLand(i2));

        Assert.AreEqual(i1.Coins, 7);
        Assert.AreEqual(i2.Coins, 0);
    }

    [Test]
    public void TestGetNextSpace()
    {
        GameObject space1 = CreateBlueSpace();
        GameObject space2 = CreateBlueSpace();
        GameObject edge = GraphTest.CreateEdge(space1, space2);
        AbstractSpace space1Component = space1.GetComponent<AbstractSpace>();
        Assert.AreEqual(space1Component.GetNextSpace(), space2);
    }
}
