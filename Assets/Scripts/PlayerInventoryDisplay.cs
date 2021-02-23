using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour
{
    [SerializeField] private PlayerInventory _player;
    [SerializeField] private Text _starCountText;
    [SerializeField] private Text _coinsCountText;
    void Start()
    {
        _player.InventoryChange += OnInventoryChange;
        UpdateInventoryDisplay();
    }

    public void OnInventoryChange(System.Object sender, EventArgs e)
    {
        UpdateInventoryDisplay();
    }

    private void UpdateInventoryDisplay()
    {
        _starCountText.text = _player.Stars.ToString();
        _coinsCountText.text = _player.Coins.ToString();
    }
}
