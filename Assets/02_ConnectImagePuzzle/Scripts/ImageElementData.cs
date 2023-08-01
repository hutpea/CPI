using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ImageElementData
{
    public string imageID;
    public int sortingLayer;
    public int puzzleLayer;
    public Vector2 anchorPosition;
    public Vector2 sizeDelta;
}

public enum ElementType
{
    PuzzlePiece, //drag piece
    PuzzleShadow,
    HiddenPiece,
    ReplacePiece,
    DeletePiece
}
