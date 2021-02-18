using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private int numberOfFaces = 10;
    private int[] faces;
    private int currentFaceIndex = 0;

    public event EventHandler FaceChange;

    public int CurrentFaceNumber
    {
        get { return faces[currentFaceIndex]; }
    }

    protected virtual void OnFaceChange()
    {
        FaceChange?.Invoke(this, EventArgs.Empty);
    }

    void Start()
    {
        CreateDiceFaces();
        RandomizeDiceFaces();
    }

    private void CreateDiceFaces()
    {
        faces = new int[numberOfFaces];
        for (int i = 0; i < numberOfFaces; i++)
        {
            faces[i] = (i + 1);
        }
    }

    private void RandomizeDiceFaces()
    {
        for (int i = faces.Length - 1; i > 1; i--)
        {
            int k = UnityEngine.Random.Range(0, faces.Length - 1);
            int toSwap = faces[k];
            faces[k] = faces[i];
            faces[i] = toSwap;
        }
    }

    public IEnumerator RollDice()
    {
        currentFaceIndex++;
        if (currentFaceIndex == faces.Length)
        {
            currentFaceIndex = 0;
        }
        OnFaceChange();
        yield return null;
    }

    public int HitDice()
    {
        StopDiceRoll();
        return 1;
    }

    private void StopDiceRoll()
    {

    }
}
