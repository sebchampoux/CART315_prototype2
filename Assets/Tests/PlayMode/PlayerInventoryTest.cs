using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerInventoryTest
{
    public static GameObject CreatePlayerGameObject()
    {
        GameObject player = new GameObject();
        player.AddComponent<PlayerInventory>();
        return player;
    }

    public static PlayerInventory CreatePlayerInventory()
    {
        GameObject player = new GameObject();
        player.AddComponent<PlayerInventory>();
        return player.GetComponent<PlayerInventory>();
    }

    [Test]
    public void TestInitialState()
    {
        PlayerInventory i = CreatePlayerInventory();
        Assert.AreEqual(i.Coins, 0);
        Assert.AreEqual(i.Stars, 0);
    }

    [Test]
    public void TestAddCoins()
    {
        PlayerInventory i1 = CreatePlayerInventory();
        PlayerInventory i2 = CreatePlayerInventory();
        i1.AddCoins(10);
        i2.AddCoins(-10);
        Assert.AreEqual(i1.Coins, 10);
        Assert.AreEqual(i2.Coins, 0);
    }

    [Test]
    public void TestRemoveCoins()
    {
        PlayerInventory i1 = CreatePlayerInventory();
        PlayerInventory i2 = CreatePlayerInventory();
        PlayerInventory i3 = CreatePlayerInventory();
        i1.AddCoins(10);
        i2.AddCoins(10);
        i3.AddCoins(10);

        i1.RemoveCoins(7);
        i2.RemoveCoins(15);
        i3.RemoveCoins(-7);

        Assert.AreEqual(i1.Coins, 3);
        Assert.AreEqual(i2.Coins, 0);
        Assert.AreEqual(i3.Coins, 3);
    }

    [Test]
    public void TestAddStars()
    {
        PlayerInventory i1 = CreatePlayerInventory();
        PlayerInventory i2 = CreatePlayerInventory();
        i1.AddStars(10);
        i2.AddStars(-10);
        Assert.AreEqual(i1.Stars, 10);
        Assert.AreEqual(i2.Stars, 0);
    }

    [Test]
    public void TestRemoveStars()
    {
        PlayerInventory i1 = CreatePlayerInventory();
        PlayerInventory i2 = CreatePlayerInventory();
        PlayerInventory i3 = CreatePlayerInventory();
        i1.AddStars(10);
        i2.AddStars(10);
        i3.AddStars(10);

        i1.RemoveStars(7);
        i2.RemoveStars(15);
        i3.RemoveStars(-7);

        Assert.AreEqual(i1.Stars, 3);
        Assert.AreEqual(i2.Stars, 0);
        Assert.AreEqual(i3.Stars, 3);
    }
}
