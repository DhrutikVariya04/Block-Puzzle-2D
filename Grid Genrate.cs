using UnityEngine;

public class GridGenerate : MonoBehaviour
{
    GameObject[] TotalPiece;

    [SerializeField]
    GameObject Space, ImagePrefab, Piece, PieceSpace;

    void Start()
    {
        TotalPiece = GameObject.FindGameObjectsWithTag("Piece");

        // GridBoard Generate :--
        for (int i = 0; i < 100; i++)
        {
            Instantiate(ImagePrefab, Space.transform);
        } 

        // Piece Generate :--
        for(int i = 0; i < 3 ; i++)
        {
            Instantiate(Piece, PieceSpace.transform);
        }
    }

    void Update()
    {

    }
}
