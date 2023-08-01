using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimLocation : MonoBehaviour
{
    [Button]
    public void SetAnimLocationToOneOfShadow()
    {
        var allPieces = FindObjectsOfType<Piece>();
        foreach(var piece in allPieces)
        {
            if(piece.elementType == ElementType.PuzzleShadow)
            {
                GetComponent<RectTransform>().anchoredPosition = piece.GetComponent<RectTransform>().anchoredPosition;
                break;
            }
        }
    }
}
