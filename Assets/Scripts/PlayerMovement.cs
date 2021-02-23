using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject dicePrefab;
    public GameObject spacesCountDisplayPrefab;
    public GameObject currentSpace;
    public Vector3 positionRelativeToCurrentCell = new Vector3(0, 1, 0); // Position offset relative
    public Vector3 dicePositionRelToCharacter = new Vector3(0, 1.2f, 0); // Position relative to character position
    public event EventHandler SpacesCountChange;
    
    private int _currentDieRoll = 0;
    private bool _dieIsRolling = false;

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
        transform.position = (currentSpace.transform.position + positionRelativeToCurrentCell);
        StartCoroutine(PlayTurn());
    }

    public IEnumerator PlayTurn()
    {
        GameObject dice = Instantiate(dicePrefab);
        dice.transform.position = transform.position + dicePositionRelToCharacter;
        Coroutine dieRolling = StartCoroutine(dice.GetComponent<Dice>().RollDice());

        _dieIsRolling = true;
        yield return new WaitWhile(() => _dieIsRolling);

        StopCoroutine(dieRolling);
        _currentDieRoll = dice.GetComponent<Dice>().CurrentFaceNumber;
        yield return new WaitForSeconds(1.0f); // Give some time to the player to see his roll
        
        Destroy(dice);
        GameObject spacesCountDisplay = Instantiate(spacesCountDisplayPrefab);
        SpacesCountDisplay spacesCountDisplayObserver = spacesCountDisplay.GetComponent<SpacesCountDisplay>();
        spacesCountDisplayObserver.playerMovement = this;
        spacesCountDisplayObserver.UpdateSpaceCountDisplay();
        SpacesCountChange += spacesCountDisplayObserver.OnSpacesCountChange;
        spacesCountDisplay.transform.SetParent(gameObject.transform);
        spacesCountDisplay.transform.position = transform.position + dicePositionRelToCharacter;

        // Move appropriate number of spaces
        // For each space, pass action
        // On land space, land action
        // End turn
        yield return null;
    }

    public void HitDie()
    {
        _dieIsRolling = false;
    }
}
