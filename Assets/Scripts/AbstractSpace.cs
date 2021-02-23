using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpace : MonoBehaviour
{
    protected IList<GameObject> _incidentEdges = new List<GameObject>();
    [SerializeField] protected bool _decreasesDiceRoll = true;

    public IList<GameObject> IncidentEdges { get { return _incidentEdges; } }
    
    public bool DecreasesDiceRoll
    {
        get { return _decreasesDiceRoll; }
    }

    public void AddIncidentEdge(GameObject e)
    {
        if (e.GetComponent<Edge>() == null)
        {
            throw new System.Exception("Passed object is not an edge");
        }
        if (!_incidentEdges.Contains(e))
        {
            _incidentEdges.Add(e);
        }
    }

    public abstract IEnumerator OnPlayerPass(PlayerInventory p);

    public abstract IEnumerator OnPlayerLand(PlayerInventory p);
}
