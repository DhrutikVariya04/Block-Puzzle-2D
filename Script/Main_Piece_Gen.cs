using System.Collections.Generic;
using UnityEngine;

public class MainPieceGen : MonoBehaviour
{
    [SerializeField] float startPos = .75f;
    [SerializeField] float offset = 2.5f;

    [SerializeField]
    GameObject[] Pieces;

    [SerializeField]
    int SpawnStartPos;

    public List<Piece_Script> dragBlock = new List<Piece_Script>(3);

    void Start()
    {
        GenratePiece();
    }

    public void DeleteData(Piece_Script piece)
    {
        dragBlock.Remove(piece);
        if (dragBlock.Count == 0) GenratePiece();
    }

    void GenratePiece()
    {
        for (int i = dragBlock.Count; i < 3; i++)
        {
            float k = startPos + (i * offset);
            GameObject Piece = Instantiate(Pieces[Random.Range(SpawnStartPos, Pieces.Length)], new Vector2(k, 0), Quaternion.identity);
            Piece.transform.SetParent(transform, false);
            dragBlock.Add(Piece.GetComponent<Piece_Script>());

        }
    }
}
