using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.SceneManagement;

#if UNITY_EDITOR
public class MapTileBrushWindow : EditorWindow
{
    private MapTileBrushSelectionOutline selectionOutline;

    private GameObject prefabRoot;

    private void CreateGUI()
    {
        prefabRoot = PrefabStageUtility.GetCurrentPrefabStage().prefabContentsRoot;

        SceneView.duringSceneGui += OnSceneGUIHandler;

        CreateSelectionOutline(prefabRoot);

        VisualElement root = rootVisualElement;

        Label modeLabel = new();
        root.Add(modeLabel);

        EnumFlagsField tileTypeField = new("tile Type", MapTileType.None);
        root.Add(tileTypeField);
    }

    private void OnDisable()
    {
        Deconstruct();
    }

    [MenuItem("Tools/Map Tile Brush")]
    private static void OnMenuItemHandler()
    {
        MapTileBrushWindow wnd = GetWindow<MapTileBrushWindow>();
        wnd.titleContent = new GUIContent("Map Tile Brush");
    }

    private void OnSceneGUIHandler(SceneView sceneView)
    {
        if (selectionOutline == null)
        {
            CreateSelectionOutline(prefabRoot);
        }

        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        if (!PrefabStageUtility.GetCurrentPrefabStage().scene.GetPhysicsScene().Raycast(ray.origin, ray.direction, out RaycastHit hitInfo))
        {
            selectionOutline.Deselect();
            return;
        };
        var go = hitInfo.collider.gameObject;
        selectionOutline.Select(go);
    }

    private void CreateSelectionOutline(GameObject prefabRoot)
    {
        selectionOutline = new GameObject("MapTileBrushSelectionOutline").AddComponent<MapTileBrushSelectionOutline>();
        selectionOutline.Setup();
        selectionOutline.transform.SetParent(prefabRoot.transform);
    }

    private void Deconstruct()
    {
        DestroyImmediate(selectionOutline.gameObject);
        SceneView.duringSceneGui -= OnSceneGUIHandler;
    }
}
#endif