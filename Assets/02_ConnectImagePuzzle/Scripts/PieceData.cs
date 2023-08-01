using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PieceData
{
    public int pieceID;
    public ElementType elementType;
    public List<ImageElementData> imageData;
    public Vector2 anchorPosition;
    public Vector2 sizeDelta;

    public SuccessConnectEffect successConnectEffect;
}

public enum SuccessConnectEffect
{
    None,
}
