using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
    public List<PieceData> pieceData;
    public List<PieceTargetPositionData> pieceTargetPositionDatas;
    public List<HiddenPieceData> hiddenPieceData;
    public List<ReplacePieceData> replacePieceData;
    public List<DeletePieceData> deletePieceData;
    public Vector2 animSpawnLocation;
}

[Serializable]
public class PieceTargetPositionData
{
    public List<int> positionIDs;
    public Vector2 anchorPosition;
    public bool hasPieceIn;
}

[Serializable]
public class HiddenPieceData {
    public int pieceID;
    public List<int> requirePiecesToUnlock;
}

[Serializable]
public class ReplacePieceData
{
    public int pieceReplacedID;
    public int pieceToReplaceID;
    public List<int> requirePiecesToUnlock;
}

[Serializable]
public class DeletePieceData
{
    public int pieceID;
    public List<int> requirePiecesToUnlock;
}
