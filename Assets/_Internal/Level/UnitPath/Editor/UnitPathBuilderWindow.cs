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
    public GameObject[] AllSelectedGOs => Selection.gameObjects;

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
        foreach (var go in AllSelectedGOs)
        {
            if (go == null) continue;
            if (go.TryGetComponent<UnitPathNode>(out var _)) continue;

            Undo.RegisterFullObjectHierarchyUndo(go, "Create node (GameObject)");
            UnitPathBuilder.AddNode(go);
            PrefabUtility.RecordPrefabInstancePropertyModifications(go);
        }
    }

    private void RemoveButtonHandler()
    {
        foreach(var go in AllSelectedGOs)
        {
            if (go == null) continue;
            if (!go.TryGetComponent<UnitPathNode>(out var node)) continue;

            if (node == SelectedNode)
            {
                SelectedNode = null;
            }

            Undo.RegisterFullObjectHierarchyUndo(go, "Remove node (GameObject)");
            UnitPathBuilder.RemoveNode(node);
            PrefabUtility.RecordPrefabInstancePropertyModifications(go);
        }
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
        foreach (var go in AllSelectedGOs)
        {
            if (go == null) continue;
            if (!go.TryGetComponent<UnitPathNode>(out var node)) continue;
            if (SelectedNode == null) continue;

            Undo.RegisterFullObjectHierarchyUndo(SelectedNode, "Connect to selected node (GameObject)");
            SelectedNode.ConnectTo(node);
            PrefabUtility.RecordPrefabInstancePropertyModifications(SelectedNode);
        }
    }

    private void SetSelectedLabelText(string text)
    {
        selectedLabel.text = "Selected node: " + text;
    }
}
