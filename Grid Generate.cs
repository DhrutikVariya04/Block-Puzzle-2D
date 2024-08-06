using System;
using UnityEngine;

public class GridGenerate : MonoBehaviour
{
    public GameObject[,] baseBlock;
    int size = 10;

    [SerializeField]
    GameObject SpawnImage;

    [SerializeField]
    Color highlight;

    public Sprite DefaultImage;

    void Start()
    {
        baseBlock = new GameObject[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var block = Instantiate(SpawnImage, new Vector2(i, j), Quaternion.identity);
                block.transform.SetParent(transform, false);
                baseBlock[i, j] = block;
            }
        }

    }

    public void Highlight(Piece_Script mainPiece)
    {
        clearHighlight();

        if (!isEmptyBase(mainPiece))
        {
            return;
        }

        var Totalchild = mainPiece.transform.childCount;

        for (int i = 0; i < Totalchild; i++)
        {
            var piece = mainPiece.transform.GetChild(i).gameObject;
            Vector2Int piecePos = converToVector2Int(piece.transform.position);

            var block = baseBlock[piecePos.x, piecePos.y];

            block.GetComponent<SpriteRenderer>().sprite = piece.GetComponent<SpriteRenderer>().sprite;
            block.transform.localScale = Vector3.one;
        }

    }

    public void clearHighlight()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var block = baseBlock[i, j].GetComponent<SpriteRenderer>();
                block.sprite = DefaultImage;
                block.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
        }
    }

    public Vector2Int converToVector2Int(Vector2 pos)
    {
        return new Vector2Int((int)(pos.x + .5f), (int)(pos.y + .5f));
    }

    public bool isEmptyBase(Piece_Script mainPiece)
    {
        var Totalchild = mainPiece.transform.childCount;

        for (int i = 0; i < Totalchild; i++)
        {
            var piece = mainPiece.transform.GetChild(i).gameObject;
            Vector2Int piecePos = converToVector2Int(piece.transform.position);

            if (!inRange(piece.transform.position))
            {
                return false;
            }

        }
        return true;
    }

    public bool inRange(Vector2 pos)
    {
        return pos.x > -0.5 && pos.y > -0.5 &&
            pos.x < size - .5 && pos.y < size - .5;
    }

    internal void Placeblock(Piece_Script mainPiece)
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isEmptyBase(mainPiece))
        {
            var Totalchild = mainPiece.transform.childCount;

            for (int i = 0; i < Totalchild; i++)
            {
                var piece = mainPiece.transform.GetChild(i).gameObject;
                Vector2Int piecePos = converToVector2Int(piece.transform.position);

                var block = baseBlock[piecePos.x, piecePos.y];

                piece.transform.position = new Vector2(piecePos.x, piecePos.y);
                block.transform.localScale = Vector3.one;

            }
            mainPiece.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            mainPiece.MoveToOriginalPos();
        }
    }
}
