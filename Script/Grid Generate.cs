using UnityEngine;
using System.Collections;

public class GridGenerate : MonoBehaviour
{
    GameObject[,] baseBlock;
    GameObject[,] fillBlock;
    int size = 10;

    [SerializeField]
    GameObject SpawnImage;

    [SerializeField]
    Color highlight;

    public Sprite DefaultImage;

    [SerializeField]
    MainPieceGen GenrateBlock;

    void Start()
    {
        baseBlock = new GameObject[size, size];
        fillBlock = new GameObject[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var block = Instantiate(SpawnImage, new Vector2(i, j), Quaternion.identity);
                block.transform.SetParent(transform, false);
                block.name = i + "" + j;
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

            if (!inRange(piece.transform.position) || fillBlock[piecePos.x, piecePos.y] != null)
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

            for (int i = Totalchild - 1; i >= 0; i--)
            {
                var piece = mainPiece.transform.GetChild(i).gameObject;
                Vector2Int piecePos = converToVector2Int(piece.transform.position);

                var block = baseBlock[piecePos.x, piecePos.y];

                piece.transform.position = new Vector2(piecePos.x, piecePos.y);
                block.transform.localScale = Vector3.one;
                fillBlock[piecePos.x, piecePos.y] = piece;
                piece.transform.SetParent(null);
            }


            mainPiece.GetComponent<BoxCollider2D>().enabled = false;
            GenrateBlock.DeleteData(mainPiece.gameObject);
            DestroyBlocks();
            Destroy(mainPiece.gameObject);

        }
        else
        {
            mainPiece.MoveToOriginalPos();
        }
    }

    void DestroyBlocks()
    {

        for (int i = 0; i < size; i++)
        {
            bool isDestoryV = true;
            bool isDestoryH = true;

            for (int j = 0; j < size; j++)
            {
                if (fillBlock[i, j] == null)
                {
                    isDestoryV = false;
                }

                if (fillBlock[j, i] == null)
                {
                    isDestoryH = false;
                }
            }

            //print(i + "---->" + isDestoryV);

            if (isDestoryV)
            {
                for (int j = 0; j < size; j++)
                {
                    fillBlock[i, j].gameObject.transform.parent = null;
                    StartCoroutine(particale(fillBlock[i, j]));
                    fillBlock[i, j] = null;
                    //Destroy(Parent);
                }
            }

            if (isDestoryH)
            {
                for (int j = 0; j < size; j++)
                {
                    fillBlock[j, i].gameObject.transform.parent = null;
                    StartCoroutine(particale(fillBlock[j, i]));
                    fillBlock[j, i] = null;
                    //Destroy(Parent);                    
                }
            }
        }
    }

    IEnumerator particale(GameObject piece)
    {
        ParticleSystem Particle = piece.GetComponent<ParticleSystem>();

        Particle.Play();

        piece.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);

        Particle.Stop();

        Destroy(piece);
    }
}
