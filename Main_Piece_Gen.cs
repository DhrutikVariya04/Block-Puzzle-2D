using UnityEngine;

public class MainPieceGen : MonoBehaviour
{
    [SerializeField]
    GameObject[] Pieces;

    [SerializeField]
    float startPos = .75f;

    [SerializeField]
    float offset = 2.5f;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            float k = startPos +  (i * offset);
            var Piece = Instantiate(Pieces[Random.Range(6,Pieces.Length)], new Vector2(k,0), Quaternion.identity);
            Piece.transform.SetParent(transform, false);
        }
    }
}
