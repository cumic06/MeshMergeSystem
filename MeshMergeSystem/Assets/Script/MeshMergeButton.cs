using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshMergeSystem))]
public class MeshMergeButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MeshMergeSystem meshMergeSystem = (MeshMergeSystem)target;

        if (GUILayout.Button("MeshMerge"))
        {
            meshMergeSystem.MeshMerge();
        }

        if (GUILayout.Button("DeMergeMesh"))
        {
            meshMergeSystem.DeMergeMesh();
        }
    }
}
