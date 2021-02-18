using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GraphTest
{
    public static GameObject CreateEdge(GameObject from, GameObject to)
    {
        GameObject edgeGO = new GameObject();
        edgeGO.SetActive(false);
        edgeGO.AddComponent<Edge>();

        Edge edgeComponent = edgeGO.GetComponent<Edge>();
        edgeComponent.Source = from;
        edgeComponent.Destination = to;

        edgeGO.SetActive(true);
        return edgeGO;
    }

    [Test]
    public void TestAdjacencyList()
    {
        GameObject space1 = SpacesTest.CreateBlueSpace();
        GameObject space2 = SpacesTest.CreateBlueSpace();
        GameObject edge = CreateEdge(space1, space2);
        AbstractSpace as1 = space1.GetComponent<AbstractSpace>();
        AbstractSpace as2 = space2.GetComponent<AbstractSpace>();

        Assert.IsTrue(as1.IncidentEdges.Contains(edge));
        Assert.IsTrue(as2.IncidentEdges.Contains(edge));
    }

    [Test]
    public void TestAdjacencyListNoDuplication()
    {
        GameObject space1 = SpacesTest.CreateBlueSpace();
        GameObject space2 = SpacesTest.CreateBlueSpace();
        GameObject edge = CreateEdge(space1, space2);

        AbstractSpace as1 = space1.GetComponent<AbstractSpace>();
        Assert.IsTrue(as1.IncidentEdges.Count == 1);
    }

    [Test]
    public void TestCantOverwriteNodesInEdge()
    {
        GameObject space1 = SpacesTest.CreateBlueSpace();
        GameObject space2 = SpacesTest.CreateBlueSpace();
        GameObject edge = CreateEdge(space1, space2);
        Edge edgeComponent = edge.GetComponent<Edge>();

        Assert.IsTrue(edgeComponent.Source == space1);
        Assert.IsTrue(edgeComponent.Destination == space2);

        edgeComponent.Source = space2;
        edgeComponent.Destination = space1;

        Assert.IsTrue(edgeComponent.Source == space1);
        Assert.IsTrue(edgeComponent.Destination == space2);
    }
}
