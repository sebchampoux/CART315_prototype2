using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject[] spaces;
    [SerializeField] private GameObject[] edges;
    [SerializeField] private AbstractSpace[] _potentialStarSpaces;
}
