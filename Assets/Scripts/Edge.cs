using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    [SerializeField] private GameObject _source;
    [SerializeField] private GameObject _destination;

    public GameObject Source
    {
        get { return _source; }
        set { if (_source == null) { _source = value; } }
    }
    public GameObject Destination
    {
        get { return _destination; }
        set { if (_destination == null) { _destination = value; } }
    }

    void Awake()
    {
        AddEdgeToNodesAdjacencyList();
    }

    private void AddEdgeToNodesAdjacencyList()
    {
        _source.GetComponent<AbstractSpace>().AddIncidentEdge(gameObject);
        _destination.GetComponent<AbstractSpace>().AddIncidentEdge(gameObject);
    }
}
