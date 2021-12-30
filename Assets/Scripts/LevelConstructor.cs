using System.Collections.Generic;
using UnityEngine;

public class LevelConstructor : MonoBehaviour
{
    [SerializeField] private GameObject stoneRow;
    [SerializeField] private GameObject stoneColumn;
    [SerializeField] private Vector2 offset;
    private int[,] blockArray;
    private bool numberWall;

    public void AddNewWall()
    {
        blockArray = new int[40, 40];
        for (int x = 2; x < 37; x++)
        {
            for (int y = 4; y < 37; y++)
            {
                if (blockArray[x, y] != 0) continue;

                numberWall = Random.value > 0.02;
                if (numberWall) continue;

                bool horizontalWall = Random.value > 0.5f;

                if (horizontalWall)
                {
                    if (blockArray[x + 1, y] != 0) continue;
                    blockArray[x, y] = 1;
                    blockArray[x + 1, y] = 1;
                    var hWall = Instantiate(stoneRow, new Vector2(x, y) + offset, Quaternion.identity);
                    Pathfinding.Instance.GetGrid().GetGridObject(hWall.transform.position).SetIsWalkable(false);
                    Pathfinding.Instance.GetGrid().GetGridObject(new Vector3(hWall.transform.position.x + 1.5f, hWall.transform.position.y + 1f)).SetIsWalkable(false);
                }
                else
                {
                    if (blockArray[x, y + 1] != 0) continue;
                    blockArray[x, y] = 1;
                    blockArray[x, y + 1] = 1;
                    var vWall = Instantiate(stoneColumn, new Vector2(x, y) + offset, Quaternion.identity);
                    Pathfinding.Instance.GetGrid().GetGridObject(vWall.transform.position).SetIsWalkable(false);
                    Pathfinding.Instance.GetGrid().GetGridObject(new Vector3(vWall.transform.position.x + 1f, vWall.transform.position.y + 1.5f)).SetIsWalkable(false);
                }
            }
        }
    }

}
