using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageGenrate : MonoBehaviour
{
    [SerializeField]
    GameObject Space, ImagePrefab, Piece, PieceSpace;


    void Start()
    {
        for (int i = 1; i <= 100; i++)
        {
            Instantiate(ImagePrefab, Space.transform);
        }

        Instantiate(Piece, PieceSpace.transform);
    }

    // Update is called once per frame
    void Update()
    {
        /*if ()
        {
            
        }*/
    }
}
