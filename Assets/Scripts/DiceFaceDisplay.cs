using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceFaceDisplay : MonoBehaviour
{
    [SerializeField] private Dice dice;

    void Start()
    {
        dice.FaceChange += OnDiceFaceChanged;
    }

    public void OnDiceFaceChanged(System.Object sender, EventArgs e)
    {
        GetComponent<TextMeshPro>().text = dice.CurrentFaceNumber.ToString();
    }
}
