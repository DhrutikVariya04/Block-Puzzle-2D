using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGenerate : MonoBehaviour
{
    float k;

    [SerializeField]
    GameObject Pieces;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            if (i == 1) k = 0.75f;else if (i == 2)k = 3.25f;else if (i == 3)k = 5.6f;
            var Piece = Instantiate(Pieces, new Vector2(k, -3.75f), Quaternion.identity);
            Piece.transform.SetParent(transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
