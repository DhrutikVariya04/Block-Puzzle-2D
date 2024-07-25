using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerate : MonoBehaviour
{
    GameObject[] TotalPiece;

    [SerializeField]
    GameObject Space, ImagePrefab, Piece, PieceSpace;

    void Start()
    {
        TotalPiece = GameObject.FindGameObjectsWithTag("Piece");

        for (int i = 0; i < 100; i++)
        {
            Instantiate(ImagePrefab, Space.transform);
        } 

        for(int i = 0; i < 3 ; i++)
        {
            Instantiate(Piece, PieceSpace.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
       /*if (TotalPiece.Length < 3 || TotalPiece.Length == null)
        {
            Instantiate(Piece, PieceSpace.transform);
        }*/
    }
}
