using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitPathBuilderWindow : EditorWindow
{
    private Label selectedLabel;

    private UnitPathNode selectedNode;

    public UnitPathNode SelectedNode
    {
        get => selectedNode;
        private set
        {
            if (value == null)
                SetSelectedLabelText("null");
            else
                SetSelectedLabelText(value.transform.position.ToString());

            selectedNode = value;
        }
    }

    public GameObject SelectedGO => Selection.gameObjects[0];

    [MenuItem("Tools/Unit Path Builder")]
    public static void ShowExample()
    {
        UnitPathBuilderWindow wnd = GetWindow<UnitPathBuilderWindow>();
        wnd.titleContent = new GUIContent("Unit Path Builder");
    }

    public void CreateGUI()
    {
        selectedNode = null;

        VisualElement root = rootVisualElement;

        Button createButton = new(CreateButtonHandler)
        {
            text = "Create node"
        };
        root.Add(createButton);


        Button removeButton = new(RemoveButtonHandler)
        {
            text = "Remove node"
        };
        root.Add(removeButton);

        selectedLabel = new();
        SetSelectedLabelText("null");
        root.Add(selectedLabel);

        Button selectButton = new(SelectButtonHandler)
        {
            text = "Select node"
        };
        root.Add(selectButton);

        Button connectToSelectedButton = new(ConnectToSelectedButtonHandler)
        {
            text = "Connect to selected node"
        };
        root.Add(connectToSelectedButton);
    }

    private void CreateButtonHandler()
    {
        if (SelectedGO == null) return;
        if (SelectedGO.TryGetComponent<UnitPathNode>(out var _)) return;
        UnitPathBuilder.AddNode(SelectedGO);
    }

    private void RemoveButtonHandler()
    {
        if (SelectedGO == null) return;
        if (!SelectedGO.TryGetComponent<UnitPathNode>(out var node)) return;

        if (node == SelectedNode)
        {
            SelectedNode = null;
        }

        UnitPathBuilder.RemoveNode(node);
    }

    private void SelectButtonHandler()
    {
        if (SelectedGO == null) return;
        if(!SelectedGO.TryGetComponent<UnitPathNode>(out var node))
        {
            SelectedNode = null;
            return;
        }
        SelectedNode = node;
    }

    private void ConnectToSelectedButtonHandler()
    {
        if (SelectedGO == null) return;
        if (!SelectedGO.TryGetComponent<UnitPathNode>(out var node)) return;
        if (SelectedNode == null) return;

        SelectedNode.ConnectTo(node);
    }

    private void SetSelectedLabelText(string text)
    {
        selectedLabel.text = "Selected node: " + text;
    }
}
