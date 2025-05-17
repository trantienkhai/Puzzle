using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTetromino : MonoBehaviour
{
    public GameObject[] tetrominos;
 

    private void Start()
    {
        SpawnTetrominos();
    }

    public void SpawnTetrominos()
    {
        Instantiate(tetrominos[Random.Range(0, tetrominos.Length)], this.transform.position, Quaternion.identity);
    }
}
