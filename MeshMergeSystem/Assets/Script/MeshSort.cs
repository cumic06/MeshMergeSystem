using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshSort : MonoBehaviour
{
    public GameObject parent; // ������ ������Ʈ ������
    private List<Transform> meshList = new();
    public int row;
    public float spacing = 2f; // ������Ʈ ���� ����

    [ContextMenu("GridGen")]
    void MoveObjects()
    {
        meshList = parent.GetComponentsInChildren<Transform>().ToList();
        meshList.RemoveAt(0);
        int column = Mathf.CeilToInt((float)meshList.Count / row); // ���� ���� ���

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                int index = i * column + j;
                if (index < meshList.Count)
                {
                    // �� ��� ���� ������Ʈ�� ��ġ �̵�
                    Vector3 newPosition = new(j * spacing, 0, i * spacing);
                    meshList[index].transform.position = newPosition;
                }
            }
        }
    }
}