using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockLogic : MonoBehaviour
{
    private float previousTime;

    public static int width = 15;
    public static int height = 20;

    public Vector3 pivotPoint;

    public static Transform[,] grid = new Transform[width,height];
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left;
            if (!Limites())
            {
                this.transform.position -= Vector3.left;
            }
           
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right;
            if (!Limites())
            {
                this.transform.position -= Vector3.right;
            }
        }

        if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? ScoreManager.instance.fallTime/20 : ScoreManager.instance.fallTime))
        {
            this.transform.position += Vector3.down;
            if (!Limites())
            {
                this.transform.position -= Vector3.down;
                AddToGrid();
                CheckAndClearLine();
                this.enabled = false;
                FindObjectOfType<LogicTetromino>().SpawnTetrominos();
            }
            previousTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.RotateAround(transform.TransformPoint(pivotPoint), Vector3.forward, -90);
            if (!Limites())
            {
                this.transform.RotateAround(transform.TransformPoint(pivotPoint), Vector3.forward, 90);

            }
        }

    }

    private bool Limites()
    {
        foreach(Transform child in this.transform)
        {
            int enterOx = Mathf.RoundToInt(child.position.x);
            int enterOy = Mathf.RoundToInt(child.position.y);
            if (enterOx < 0 || enterOx >= width || enterOy < 0 || enterOy >= height)
            {
                return false;
            }

            if (grid[enterOx, enterOy] != null) return false;
        }
        return true;
    }

    private void AddToGrid()
    {
        foreach (Transform child in this.transform)
        {
            int enterOx = Mathf.RoundToInt(child.position.x);
            int enterOy = Mathf.RoundToInt(child.position.y);
            grid[enterOx,enterOy] = child;
            if(enterOy >= height - 1)
            {
                ScoreManager.instance.ResetAll();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void CheckAndClearLine()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (IsLineFull(i))
            {
                ClearLine(i);
                MoveDown(i);
            }
        }
    }

    private bool IsLineFull(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null) return false;
        }
        ScoreManager.instance.AddScore(50);
        return true;
    }

    private void ClearLine(int i)
    {
        for(int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }


    private void MoveDown(int i)
    {
        for(int y = i + 1; y < height; y++)
        {
            for(int j = 0; j < width; j++)
            {
                if (grid[j,y] != null)
                {
                    grid[j , y - 1] = grid[j,y];
                    grid[j,y] = null;
                    grid[j,y - 1].position += Vector3.down;
                }
            }
        }
    }
}
