using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _stars = 0;
    [SerializeField] private int _coins = 0;
    public int Stars
    {
        get { return _stars; }
        private set { _stars = Mathf.Max(value, 0); }
    }
    public int Coins
    {
        get { return _coins; }
        private set { _coins = Mathf.Max(value, 0); }
    }

    public void AddCoins(int coins)
    {
        Coins += Mathf.Max(coins, 0);
    }

    public void AddStars(int stars)
    {
        Stars += Mathf.Max(stars, 0);
    }

    public int RemoveCoins(int coinsToRemove)
    {
        int removedCoins = Mathf.Min(Mathf.Abs(coinsToRemove), Coins);
        Coins -= removedCoins;
        return removedCoins;
    }

    public int RemoveStars(int starsToRemove)
    {
        int removedStars = Mathf.Min(Mathf.Abs(starsToRemove), Stars);
        Stars -= removedStars;
        return removedStars;
    }
}
