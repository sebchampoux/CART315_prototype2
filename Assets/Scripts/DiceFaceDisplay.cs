using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceFaceDisplay : MonoBehaviour
{
    [SerializeField] private Dice dice;
    private TextMeshPro _textMesh;

    void Start()
    {
        dice.FaceChange += OnDiceFaceChanged;
        _textMesh = GetComponent<TextMeshPro>();
        UpdateFaceNumberDisplay(); // Set initial value
    }

    public void OnDiceFaceChanged(System.Object sender, EventArgs e)
    {
        UpdateFaceNumberDisplay();
    }

    private void UpdateFaceNumberDisplay()
    {
        _textMesh.text = dice.CurrentFaceNumber.ToString();
    }
}
