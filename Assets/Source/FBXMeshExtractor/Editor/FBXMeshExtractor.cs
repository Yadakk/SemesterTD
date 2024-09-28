using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public static class FBXMeshExtractor
{
    private const string PROGRESS_TITLE = "Extracting Meshes";
    private const string SOURCE_EXTENSION = ".fbx";
    private const string TARGET_EXTENSION = ".asset";

    [MenuItem("Assets/Extract Meshes", validate = true)]
    private static bool ExtractMeshesMenuItemValidate()
    {
        for (int i = 0; i < Selection.objects.Length; i++)
        {
            if (!AssetDatabase.GetAssetPath(Selection.objects[i]).EndsWith(SOURCE_EXTENSION))
                return false;
        }
        return true;
    }

    [MenuItem("Assets/Extract Meshes")]
    private static void ExtractMeshesMenuItem()
    {
        EditorUtility.DisplayProgressBar(PROGRESS_TITLE, "", 0);
        for (int i = 0; i < Selection.objects.Length; i++)
        {
            EditorUtility.DisplayProgressBar(PROGRESS_TITLE, Selection.objects[i].name, (float)i / (Selection.objects.Length - 1));
            ExtractMeshes(Selection.objects[i]);
        }
        EditorUtility.ClearProgressBar();
    }

    private static void ExtractMeshes(Object selectedObject)
    {
        //Create Folder Hierarchy
        string selectedObjectPath = AssetDatabase.GetAssetPath(selectedObject);
        string parentfolderPath = selectedObjectPath.Substring(0, selectedObjectPath.Length - (selectedObject.name.Length + 5));
        string objectFolderName = selectedObject.name;
        string objectFolderPath = parentfolderPath + "/" + objectFolderName;
        string meshFolderName = "Meshes";
        string meshFolderPath = objectFolderPath + "/" + meshFolderName;

        if (!AssetDatabase.IsValidFolder(objectFolderPath))
        {
            AssetDatabase.CreateFolder(parentfolderPath, objectFolderName);

            if (!AssetDatabase.IsValidFolder(meshFolderPath))
            {
                AssetDatabase.CreateFolder(objectFolderPath, meshFolderName);
            }
        }

        //Create Meshes
        Object[] objects = AssetDatabase.LoadAllAssetsAtPath(selectedObjectPath);

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] is Mesh)
            {
                EditorUtility.DisplayProgressBar(PROGRESS_TITLE, selectedObject.name + " : " + objects[i].name, (float)i / (objects.Length - 1));

                Mesh mesh = Object.Instantiate(objects[i]) as Mesh;

                AssetDatabase.CreateAsset(mesh, meshFolderPath + "/" + objects[i].name + TARGET_EXTENSION);
            }
        }

        //Cleanup
        AssetDatabase.MoveAsset(selectedObjectPath, objectFolderPath + "/" + selectedObject.name + SOURCE_EXTENSION);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
#endif