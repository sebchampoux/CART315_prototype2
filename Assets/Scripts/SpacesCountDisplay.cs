using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpacesCountDisplay : MonoBehaviour
{
    private TextMeshPro _textMesh;
    public PlayerTurn playerTurn;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshPro>();
    }

    public void OnSpacesCountChange(System.Object sender, EventArgs e)
    {
        UpdateSpaceCountDisplay();
    }

    public void UpdateSpaceCountDisplay()
    {
        if (playerTurn.CurrentDieRoll <= 0 && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        _textMesh.text = playerTurn.CurrentDieRoll.ToString();
    }

    private void OnDestroy()
    {
        
    }
}
