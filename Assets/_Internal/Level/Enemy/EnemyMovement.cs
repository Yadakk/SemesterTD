using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private Renderer _renderer;

    private UnitPathNode currentNode;
    private UnitPathNode targetNode;

    private Vector3 currentNodePosition;
    private Vector3 targetNodePosition;

    private float nodeDistance;

    private float nodeProgress01;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

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

        currentNodePosition = _renderer.bounds.GetPositionOnTop(currentNode.GetComponent<Collider>().bounds);
        targetNodePosition = _renderer.bounds.GetPositionOnTop(targetNode.GetComponent<Collider>().bounds);

        nodeDistance = Vector3.Distance(currentNodePosition, targetNodePosition);
    }

    private UnitPathNode GetNextNode(UnitPathNode node)
    {
        if (node.ConnectedNodes.Count == 0)
        {
            var towerHealth = node.GetComponentInChildren<HealthDisplayer>();
            towerHealth.Health -= 1f;
            Destroy(gameObject);
        }

        return node.ConnectedNodes[Random.Range(0, node.ConnectedNodes.Count)];
    }
}
