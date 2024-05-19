using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class MeshMergeSystem : MonoBehaviour
{
    [SerializeField] private GameObject parentMesh;
    private List<MeshFilter> meshList;
    [SerializeField] private MeshFilter targetMesh;

    public void MeshMerge()
    {
        meshList = parentMesh.GetComponentsInChildren<MeshFilter>().ToList();
        meshList.Remove(meshList[0]);

        var combine = new CombineInstance[meshList.Count];

        for (int i = 0; i < meshList.Count; i++)
        {
            combine[i].mesh = meshList[i].sharedMesh;
            combine[i].transform = meshList[i].transform.localToWorldMatrix;
        }

        var mesh = new Mesh();

        mesh.CombineMeshes(combine);

        targetMesh.mesh = mesh;
        SaveMesh(targetMesh.sharedMesh, gameObject.name, false, true);

        for (int i = 0; i < parentMesh.transform.childCount; i++)
        {
            parentMesh.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void DeMergeMesh()
    {
        parentMesh.GetComponent<MeshFilter>().mesh = null;

        for (int i = 0; i < parentMesh.transform.childCount; i++)
        {
            parentMesh.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void SaveMesh(Mesh mesh, string name, bool makeNewInstance, bool optimizeMesh)
    {
        string path = EditorUtility.SaveFilePanel("Save Separate Mesh Asset", "Assets/", name, "asset");

        if (string.IsNullOrEmpty(path)) return;

        path = FileUtil.GetProjectRelativePath(path);

        Mesh meshToSave = makeNewInstance ? Instantiate(mesh) : mesh;

        if (optimizeMesh)
        {
            MeshUtility.Optimize(meshToSave);
        }

        AssetDatabase.CreateAsset(meshToSave, path);
        AssetDatabase.SaveAssets();
    }
}
