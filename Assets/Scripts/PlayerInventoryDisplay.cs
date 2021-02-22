using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryDisplay : MonoBehaviour
{
    [SerializeField] private PlayerInventory _player;

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

    }
}
