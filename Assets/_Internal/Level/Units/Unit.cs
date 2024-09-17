using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private UnitPathNode currentNode;
    private UnitPathNode targetNode;

    private Vector3 currentNodePosition;
    private Vector3 targetNodePosition;

    private float nodeDistance;

    private float nodeProgress01;

    private void Update()
    {
        if (nodeProgress01 >= 1f)
        {
            SetCurrentNode(targetNode);
        }

        transform.position = Vector3.Lerp(currentNodePosition, targetNodePosition, nodeProgress01);
        nodeProgress01 += Time.deltaTime / nodeDistance * speed;
    }

    public void SetCurrentNode(UnitPathNode node)
    {
        nodeProgress01 = 0f;

        currentNode = node;
        targetNode = GetNextNode(node);

        currentNodePosition = currentNode.transform.position;
        currentNodePosition.y = transform.position.y;

        targetNodePosition = targetNode.transform.position;
        targetNodePosition.y = transform.position.y;

        nodeDistance = Vector3.Distance(currentNodePosition, targetNodePosition);
    }

    private UnitPathNode GetNextNode(UnitPathNode node)
    {
        if (node.ConnectedNodes.Count == 0)
        {
            var towerLocation = node.GetComponent<TowerLocation>();
            towerLocation.TowerHealth.Health -= 1f;
            Destroy(gameObject);
        }

        return node.ConnectedNodes[Random.Range(0, node.ConnectedNodes.Count)];
    }
}
