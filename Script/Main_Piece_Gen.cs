using System.Collections.Generic;
using UnityEngine;

public class MainPieceGen : MonoBehaviour
{
    float startPos = .75f;
    float offset = 2.5f;

    [SerializeField]
    GameObject[] Pieces;

    [SerializeField]
    int SpawnStartPos;

    [SerializeField]
    Vector2 checkCenter;

    public List<GameObject> dragBlock = new List<GameObject>(3);

    void Start()
    {
        GenratePiece();
    }



    public void DeleteData(GameObject piece)
    {
        dragBlock.Remove(piece);
        if(dragBlock.Count == 0) GenratePiece();
    }

    void GenratePiece()
    {
        for (int i = dragBlock.Count; i < 3; i++)
        {
            float k = startPos + (i * offset);
            GameObject Piece = Instantiate(Pieces[Random.Range(SpawnStartPos, Pieces.Length)], new Vector2(k, 0), Quaternion.identity);
            Piece.transform.SetParent(transform, false);
            dragBlock.Add(Piece);

        }
    }
}
