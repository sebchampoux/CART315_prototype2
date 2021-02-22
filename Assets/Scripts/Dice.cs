using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private float _rollTime = 0.1f;
    [SerializeField] private int _numberOfFaces = 10;
    private int[] _faces;
    private int _currentFaceIndex = 0;
    private bool _isRolling = false;

    public event EventHandler FaceChange;
    public int CurrentFaceNumber
    {
        get { return _faces[_currentFaceIndex]; }
    }
    public float RollTime
    {
        get { return _rollTime; }
    }

    protected virtual void OnFaceChange()
    {
        FaceChange?.Invoke(this, EventArgs.Empty);
    }

    void Awake()
    {
        CreateDiceFaces();
        RandomizeDiceFaces();
    }

    private void CreateDiceFaces()
    {
        _faces = new int[_numberOfFaces];
        for (int i = 0; i < _numberOfFaces; i++)
        {
            _faces[i] = (i + 1);
        }
    }

    private void RandomizeDiceFaces()
    {
        for (int i = _faces.Length - 1; i > 1; i--)
        {
            int k = UnityEngine.Random.Range(0, _faces.Length - 1);
            int toSwap = _faces[k];
            _faces[k] = _faces[i];
            _faces[i] = toSwap;
        }
    }

    public IEnumerator RollDice()
    {
        _isRolling = true;
        while (_isRolling)
        {
            ChangeCurrentFace();
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }

    private void ChangeCurrentFace()
    {
        _currentFaceIndex++;
        if (_currentFaceIndex == _faces.Length)
        {
            _currentFaceIndex = 0;
        }
        OnFaceChange();
    }

    public void HitDice()
    {
        _isRolling = false;
    }
}
