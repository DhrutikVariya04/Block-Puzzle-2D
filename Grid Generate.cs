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

    public void Highlight(Piece_Script pickedObject)
    {
        clearHighlight();

        if (!isEmptyBase(pickedObject))
        {
            return;
        }

        var Totalchild = pickedObject.transform.childCount;

        for (int i = 0; i < Totalchild; i++)
        {
            var piece = pickedObject.transform.GetChild(i).gameObject;
            Vector2Int piecePos = converToVector2Int(piece.transform.position);

            var block = baseBlock[piecePos.x, piecePos.y];

            if (piece.transform.tag == "Piece")
            {
                block.GetComponent<SpriteRenderer>().sprite = piece.GetComponent<SpriteRenderer>().sprite;
                block.transform.localScale = Vector3.one;
            }

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

        print("***********");
        for (int i = 0; i < Totalchild; i++)
        {
            var piece = mainPiece.transform.GetChild(i).gameObject;
            Vector2Int piecePos = converToVector2Int(piece.transform.position);

            if (!inRangeBase(piecePos))
            {
                print("false ===> " + piecePos);
                return false;
            }
            else
            {
                print("true ===> " + piecePos);
            }

        }
        return true;
    }

    public bool inRange(Vector2 pos)
    {
        return pos.x > -0.5 && pos.y > -0.5 &&
            pos.x < size - .5 && pos.y < size - .5;
    }

    public bool inRangeBase(Vector2 pos)
    {
        return pos.x >= 0 && pos.y >= 0 &&
            pos.x < size && pos.y < size;
    }
}
