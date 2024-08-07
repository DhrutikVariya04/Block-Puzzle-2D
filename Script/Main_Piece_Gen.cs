using UnityEngine;

public class MainPieceGen : MonoBehaviour
{
    float startPos = .75f;
    float offset = 2.5f;

    [SerializeField]
    GameObject[] Pieces;

    [SerializeField]
    int SpawnStartPos;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            float k = startPos + (i * offset);
            var Piece = Instantiate(Pieces[Random.Range(SpawnStartPos, Pieces.Length)], new Vector2(k, 0), Quaternion.identity);
            Piece.transform.SetParent(transform, false);
        }
    }

    private void Update()
    {
        var mainPieace = GameObject.FindGameObjectsWithTag("MainPiece");

        for (int i = 0; i < 3 - mainPieace.Length; i++)
        {
            float k = startPos + (i * offset);
            var Piece = Instantiate(Pieces[Random.Range(SpawnStartPos, Pieces.Length)], new Vector2(k, 0), Quaternion.identity);
            Piece.transform.SetParent(transform, false);
        }
    }
}
