using UnityEngine;

public class MainPieceGen : MonoBehaviour
{
    private float k;

    [SerializeField]
    GameObject[] Pieces;

    void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            if (i == 1) 
                k = 0.75f;
            else if (i == 2)
                k = 3.25f;
            else if (i == 3)
                k = 5.6f;
            var Piece = Instantiate(Pieces[Random.Range(4,Pieces.Length)], new Vector2(k,0), Quaternion.identity);
            Piece.transform.SetParent(transform, false);
        }
    }
}
