using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPathNode : MonoBehaviour
{
    [SerializeField]
    private List<UnitPathNode> connectedNodes = new();

    public Vector3 Offset => new(0f, 1f, 0f);

    public List<UnitPathNode> ConnectedNodes
    {
        get
        {
            for (int i = 0; i < connectedNodes.Count; i++)
            {
                if (connectedNodes[i] == null)
                    connectedNodes.Remove(connectedNodes[i]);
            }

            return connectedNodes;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + Offset, 0.2f);

        foreach (UnitPathNode node in ConnectedNodes)
        {
            if (node == null) continue;

            Gizmos.color = Color.magenta;

            Vector3 switchColorPoint = Vector3.MoveTowards(node.transform.position, transform.position, 0.4f) + Offset;

            Gizmos.DrawLine(
                transform.position + Offset,
                switchColorPoint);

            Gizmos.color = Color.green;

            Gizmos.DrawLine(
                switchColorPoint,
                node.transform.position + Offset);
        }
    }

    public void ConnectTo(UnitPathNode node)
    {
        if (node == this) return;
        if (ConnectedNodes.Contains(node)) return;
        ConnectedNodes.Add(node);
    }
}
