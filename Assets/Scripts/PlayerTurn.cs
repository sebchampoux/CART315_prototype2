using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public GameObject dicePrefab;
    public GameObject spacesCountDisplayPrefab;
    public GameObject currentSpace;
    public Vector3 positionRelativeToCurrentCell = new Vector3(0, 0, 0); // Position offset relative to the space position
    public Vector3 dicePositionRelToCharacter = new Vector3(0, 1.2f, 0); // Position relative to character position
    public event EventHandler SpacesCountChange;

    private GameObject _dice;
    private int _currentDieRoll = 0;
    private bool _dieIsRolling = false;
    private Coroutine _dieRollingCoroutine = null;
    private GameObject _spacesCountDisplay;

    public int CurrentDieRoll
    {
        get { return _currentDieRoll; }
        private set { _currentDieRoll = Mathf.Max(0, value); }
    }

    protected virtual void OnSpaceCountChange()
    {
        SpacesCountChange?.Invoke(this, EventArgs.Empty);
    }

    private void Start()
    {
        PositionCharacterAtFirstSpace();
    }

    private void PositionCharacterAtFirstSpace()
    {
        transform.position = currentSpace.transform.position + positionRelativeToCurrentCell;
    }

    public IEnumerator PlayTurn()
    {
        CreateDie();
        RollDie();
        yield return new WaitWhile(() => _dieIsRolling);
        StopDieRoll();
        yield return new WaitForSeconds(1.5f); // Give some time to the player to see what he got
        Destroy(_dice);
        CreateSpacesCountDisplay();
        while (_currentDieRoll > 0)
        {
            MoveToNextSpace();
            IEnumerator currentSpacePassEvent = currentSpace.GetComponent<AbstractSpace>().OnPlayerPass(gameObject);
            StartCoroutine(currentSpacePassEvent);
            yield return new WaitForSeconds(0.5f);
        }
        IEnumerator currentSpaceLandEvent = currentSpace.GetComponent<AbstractSpace>().OnPlayerLand(gameObject);
        StartCoroutine(currentSpaceLandEvent);
        DestroySpacesDisplay();
        yield return null;
    }

    private void CreateDie()
    {
        _dice = Instantiate(dicePrefab);
        _dice.transform.SetParent(gameObject.transform);
        _dice.transform.position = transform.position + dicePositionRelToCharacter;
    }

    private void RollDie()
    {
        _dieIsRolling = true;
        _dieRollingCoroutine = StartCoroutine(_dice.GetComponent<Dice>().RollDice());
    }

    private void StopDieRoll()
    {
        StopCoroutine(_dieRollingCoroutine);
        _currentDieRoll = _dice.GetComponent<Dice>().CurrentFaceNumber;
    }

    private void CreateSpacesCountDisplay()
    {
        _spacesCountDisplay = Instantiate(spacesCountDisplayPrefab);
        BindSpacesCountDisplayToTurn();
        PositionSpacesCountDisplay();
        _spacesCountDisplay.GetComponent<SpacesCountDisplay>().UpdateSpaceCountDisplay(); // Set initial value
    }

    private void BindSpacesCountDisplayToTurn()
    {
        SpacesCountDisplay spacesCountDisplayObserver = _spacesCountDisplay.GetComponent<SpacesCountDisplay>();
        spacesCountDisplayObserver.playerTurn = this;
        SpacesCountChange += spacesCountDisplayObserver.OnSpacesCountChange;
    }

    private void PositionSpacesCountDisplay()
    {
        _spacesCountDisplay.transform.SetParent(gameObject.transform);
        _spacesCountDisplay.transform.position = transform.position + dicePositionRelToCharacter;
    }

    /// <summary>
    /// Public method to bind to an input to stop die roll
    /// </summary>
    public void HitDie()
    {
        _dieIsRolling = false;
    }

    private void MoveToNextSpace()
    {
        currentSpace = currentSpace.GetComponent<AbstractSpace>().GetNextSpace();
        iTween.MoveTo(gameObject, currentSpace.transform.position + positionRelativeToCurrentCell, 2f);
        if (currentSpace.GetComponent<AbstractSpace>().DecreasesDiceRoll)
        {
            _currentDieRoll--;
            OnSpaceCountChange();
        }
    }

    private void DestroySpacesDisplay()
    {
        SpacesCountChange -= _spacesCountDisplay.GetComponent<SpacesCountDisplay>().OnSpacesCountChange;
        Destroy(_spacesCountDisplay);
    }
}
