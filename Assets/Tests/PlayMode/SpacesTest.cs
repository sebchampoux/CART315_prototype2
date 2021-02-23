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
        GameObject player = PlayerInventoryTest.CreatePlayerGameObject();
        GameObject blueSpace = CreateBlueSpace();

        AbstractSpace blueSpaceComponent = blueSpace.GetComponent<AbstractSpace>();
        blueSpaceComponent.StartCoroutine(blueSpaceComponent.OnPlayerLand(player));
        Assert.AreEqual(3, player.GetComponent<PlayerInventory>().Coins);
    }

    [Test]
    public void TestRedSpaceLand()
    {
        GameObject player1 = PlayerInventoryTest.CreatePlayerGameObject();
        GameObject player2 = PlayerInventoryTest.CreatePlayerGameObject();
        PlayerInventory pi1 = player1.GetComponent<PlayerInventory>();
        PlayerInventory pi2 = player2.GetComponent<PlayerInventory>();
        pi1.AddCoins(10);
        pi2.AddCoins(2);

        GameObject redSpace = CreateRedSpace();
        AbstractSpace redSpaceComponent = redSpace.GetComponent<AbstractSpace>();
        redSpaceComponent.StartCoroutine(redSpaceComponent.OnPlayerLand(player1));
        redSpaceComponent.StartCoroutine(redSpaceComponent.OnPlayerLand(player2));

        Assert.AreEqual(7, pi1.Coins);
        Assert.AreEqual(0, pi2.Coins);
    }

    [Test]
    public void TestGetNextSpace()
    {
        GameObject space1 = CreateBlueSpace();
        GameObject space2 = CreateBlueSpace();
        GameObject edge = GraphTest.CreateEdge(space1, space2);
        AbstractSpace space1Component = space1.GetComponent<AbstractSpace>();
        Assert.AreEqual(space2, space1Component.GetNextSpace());
    }
}
