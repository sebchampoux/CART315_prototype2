using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpace : MonoBehaviour
{
    protected IList<GameObject> _incidentEdges = new List<GameObject>();
    [SerializeField] protected bool _decreasesDiceRoll = true;

    public IList<GameObject> IncidentEdges
    {
        get { return _incidentEdges; }
    }

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

    public virtual GameObject GetNextSpace()
    {
        // Default implementation for simple spaces
        // For more complex (like fork spaces) implementation could be different
        foreach(GameObject edgeGO in _incidentEdges)
        {
            Edge edge = edgeGO.GetComponent<Edge>();
            if (edge.Source == this.gameObject)
            {
                return edge.Destination;
            }
        }
        return null;
    }

    public abstract IEnumerator OnPlayerPass(PlayerInventory p);

    public abstract IEnumerator OnPlayerLand(PlayerInventory p);
}
