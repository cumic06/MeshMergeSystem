using UnityEngine;

public class MeshSort : MonoBehaviour
{
    public GameObject parent; // 생성할 오브젝트 프리팹
    private Transform[] meshList;
    public int totalObjects; // 총 오브젝트 개수
    public int row;
    public float spacing = 2f; // 오브젝트 간의 간격

    [ContextMenu("GridGen")]
    void MoveObjects()
    {
        meshList = parent.GetComponentsInChildren<Transform>();
        int column = Mathf.CeilToInt((float)meshList.Length / row); // 열의 개수 계산

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                int index = i * column + j;
                if (index < meshList.Length)
                {
                    // 각 행과 열에 오브젝트의 위치 이동
                    Vector3 newPosition = new(j * spacing, 0, i * spacing);
                    meshList[index].transform.position = newPosition;
                }
            }
        }
    }
}
