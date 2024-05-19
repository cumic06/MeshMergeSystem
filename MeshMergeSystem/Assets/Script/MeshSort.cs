using UnityEngine;

public class MeshSort : MonoBehaviour
{
    public GameObject parent; // ������ ������Ʈ ������
    private Transform[] meshList;
    public int totalObjects; // �� ������Ʈ ����
    public int row;
    public float spacing = 2f; // ������Ʈ ���� ����

    [ContextMenu("GridGen")]
    void MoveObjects()
    {
        meshList = parent.GetComponentsInChildren<Transform>();
        int column = Mathf.CeilToInt((float)meshList.Length / row); // ���� ���� ���

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                int index = i * column + j;
                if (index < meshList.Length)
                {
                    // �� ��� ���� ������Ʈ�� ��ġ �̵�
                    Vector3 newPosition = new(j * spacing, 0, i * spacing);
                    meshList[index].transform.position = newPosition;
                }
            }
        }
    }
}
