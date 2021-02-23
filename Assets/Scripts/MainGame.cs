using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public PlayerTurn[] players;
    private bool _gameIsRunning;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        for (; ; )
        {
            foreach (PlayerTurn player in players)
            {
                yield return StartCoroutine(player.PlayTurn());
            }
        }
    }
}
