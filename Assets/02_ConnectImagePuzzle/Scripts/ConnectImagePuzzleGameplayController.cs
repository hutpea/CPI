using DG.Tweening;
using Sirenix.OdinInspector;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ConnectImagePuzzleGameplayController : MonoBehaviour
{
    public GameObject confettiPrefab;
    public GameObject puzzlePiecePrefab;
    public GameObject puzzleShadowPrefab;
    public GameObject layerElementPrefab;
    public Canvas gameMainCanvas;
    public Transform mainContainer;
    public Vector2 animSpawnLocation;

    [Title("Current Level Data")]
    public LevelData levelData;
    public List<Piece> allPieces;
    public List<LayerElement> allLayerElements;
    public List<HiddenPieceRealgameData> allHiddenPieceRealgameData;
    public List<ReplacePieceRealgameData> allReplacePieceRealgameData;
    public List<DeletePieceRealgameData> allDeletePieceRealgameData;
    public int currentPuzzleLayer;
    public int maxPuzzleLayer;

    public void Init()
    {
        UseProfile.CurrentLevel = 1;
        InitLevel(UseProfile.CurrentLevel);
    }

    public void InitLevel(int level)
    {
        foreach (Transform child in mainContainer)
        {
            Destroy(child.gameObject);
        }
        currentPuzzleLayer = 1;
        maxPuzzleLayer = 1;
        allLayerElements = new List<LayerElement>();
        allPieces = new List<Piece>();
        allHiddenPieceRealgameData = new List<HiddenPieceRealgameData>();

        var jsonTextFile = Resources.Load<TextAsset>("Levels/Level_" + level);
        Debug.Log(jsonTextFile.text);
        levelData = JsonUtility.FromJson<LevelData>(jsonTextFile.text);

        //UI setup
        GamePlayController.Instance.gameplayUIController.OnLevelStart(level);

        foreach (PieceData singlePieceData in levelData.pieceData)
        {
            //Create object
            GameObject obj = new GameObject("Piece " + singlePieceData.pieceID);
            Debug.Log(singlePieceData.pieceID + " type=" + singlePieceData.elementType);
            obj.transform.parent = mainContainer;
            RectTransform rect = obj.AddComponent<RectTransform>();
            //Initialize Rect position and size
            //RectTransform rect = obj.GetComponent<RectTransform>();
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = singlePieceData.anchorPosition;
            rect.sizeDelta = singlePieceData.sizeDelta;
            rect.localScale = Vector3.one;

            Piece pieceComponent = obj.AddComponent<Piece>();
            pieceComponent.pieceID = singlePieceData.pieceID;
            pieceComponent.elementType = singlePieceData.elementType;
            allPieces.Add(pieceComponent);
            
            foreach (ImageElementData imageData in singlePieceData.imageData)
            {
                GameObject layerElementObj = Instantiate(layerElementPrefab, obj.transform);
                LayerElement layerElementComponent = layerElementObj.GetComponent<LayerElement>();
                pieceComponent.layerElementList.Add(layerElementComponent);
                Image layerElementImage = layerElementComponent.GetComponent<Image>();
                layerElementComponent.Init(pieceComponent.elementType, imageData.puzzleLayer, imageData.sortingLayer);
                if (imageData.puzzleLayer > maxPuzzleLayer)
                {
                    maxPuzzleLayer = imageData.puzzleLayer;
                }
                //Initialize Rect position and size
                RectTransform layerRect = layerElementObj.GetComponent<RectTransform>();
                layerRect.anchorMax = new Vector2(0.5f, 0.5f);
                layerRect.anchorMin = new Vector2(0.5f, 0.5f);
                layerRect.pivot = new Vector2(0.5f, 0.5f);
                layerRect.anchoredPosition = imageData.anchorPosition;
                layerRect.sizeDelta = imageData.sizeDelta;
                layerRect.localScale = Vector3.one;

                //Load image sprite
                Sprite sprite = Resources.Load<Sprite>("Images/" + level + "/item/" + imageData.imageID);
                if (sprite != null)
                {
                    layerElementImage.sprite = sprite;
                }

                layerElementObj.name = layerElementImage.sprite.name;
            }

            //Add PuzzlePiece Component if this is drag piece
            if (singlePieceData.elementType == ElementType.PuzzlePiece)
            {
                Debug.Log("aaaa");
                PuzzlePiece puzzlePieceComponent = obj.AddComponent<PuzzlePiece>();
                puzzlePieceComponent.Init(singlePieceData.pieceID);
            }

            //Init puzzle shadow
            if (singlePieceData.elementType == ElementType.PuzzleShadow)
            {
                CanvasGroup canvasGroup = obj.AddComponent<CanvasGroup>();
                canvasGroup.DOFade(0f, 0.01f);
                canvasGroup.DOFade(1f, 0.3f);
            }
        }

        //Hidden Piece Data
        foreach(var _hiddenPieceData in levelData.hiddenPieceData)
        {
            HiddenPieceRealgameData _hiddenPieceRealgameData = new HiddenPieceRealgameData();
            var requirePiecesList = new List<Piece>();
            foreach (var _piece in allPieces)
            {
                if (_piece.pieceID == _hiddenPieceData.pieceID)
                {
                    _hiddenPieceRealgameData.hiddenPiece = _piece;
                    break;
                }
            }
            foreach (var _piece in allPieces)
            {
                if (_hiddenPieceData.requirePiecesToUnlock.Contains(_piece.pieceID))
                {
                    requirePiecesList.Add(_piece);
                }
            }
            if(requirePiecesList.Count > 0)
            {
                _hiddenPieceRealgameData.requirePieces = requirePiecesList;
            }

            allHiddenPieceRealgameData.Add(_hiddenPieceRealgameData);
        }

        //Replace Piece Data
        foreach (var _replacePieceData in levelData.replacePieceData)
        {
            ReplacePieceRealgameData _replacePieceRealgameData = new ReplacePieceRealgameData();
            var requirePiecesList = new List<Piece>();
            foreach (var _piece in allPieces)
            {
                if (_piece.pieceID == _replacePieceData.pieceReplacedID)
                {
                    _replacePieceRealgameData.PieceReplaced = _piece;
                }
                if (_piece.pieceID == _replacePieceData.pieceToReplaceID)
                {
                    _replacePieceRealgameData.PieceToReplace = _piece;
                }
            }
            foreach (var _piece in allPieces)
            {
                if (_replacePieceData.requirePiecesToUnlock.Contains(_piece.pieceID))
                {
                    requirePiecesList.Add(_piece);
                }
            }
            if (requirePiecesList.Count > 0)
            {
                _replacePieceRealgameData.requirePieces = requirePiecesList;
            }

            allReplacePieceRealgameData.Add(_replacePieceRealgameData);
        }

        //Delête Piece Data
        foreach (var _deletePieceData in levelData.deletePieceData)
        {
            DeletePieceRealgameData _deletePieceRealgameData = new DeletePieceRealgameData();
            var requirePiecesList = new List<Piece>();
            foreach (var _piece in allPieces)
            {
                if (_piece.pieceID == _deletePieceData.pieceID)
                {
                    _deletePieceRealgameData.deletePiece = _piece;
                    break;
                }
            }
            foreach (var _piece in allPieces)
            {
                if (_deletePieceData.requirePiecesToUnlock.Contains(_piece.pieceID))
                {
                    requirePiecesList.Add(_piece);
                }
            }
            if (requirePiecesList.Count > 0)
            {
                _deletePieceRealgameData.requirePieces = requirePiecesList;
            }

            allDeletePieceRealgameData.Add(_deletePieceRealgameData);
        }

        //Anim Location
        animSpawnLocation = levelData.animSpawnLocation;
    }

    public void Win()
    {
        GamePlayController.Instance.gameplayUIController.SetUpUIOnWin();

        //Win animation
        foreach (Transform child in mainContainer)
        {
            Destroy(child.gameObject);
        }
        SetUpAnimation(UseProfile.CurrentLevel);

        //Setup win particle effect
        Piece randomPuzzleShadow = FindObjectOfType<Piece>();
        GameObject confettiObj = Instantiate(confettiPrefab, randomPuzzleShadow.transform.position, Quaternion.identity);
        confettiObj.transform.localScale = new Vector3(2, 2, 2);
    }

    public void SetUpAnimation(int level)
    {
        
        GameObject animAsset = Resources.Load<GameObject>("Animations/" + level + "/Anim");
        if (animAsset == null) return;
        GameObject animObj = Instantiate(animAsset, mainContainer);
        animObj.GetComponent<RectTransform>().anchoredPosition = animSpawnLocation;
        SkeletonGraphic skeletonGraphic = animObj.GetComponent<SkeletonGraphic>();
        //skeletonGraphic.SetAnimation("Win");
    }
}

[Serializable]
public class HiddenPieceRealgameData
{
    public Piece hiddenPiece;
    public List<Piece> requirePieces;
}

[Serializable]
public class ReplacePieceRealgameData
{
    public Piece PieceReplaced;
    public Piece PieceToReplace;
    public List<Piece> requirePieces;
}

[Serializable]
public class DeletePieceRealgameData
{
    public Piece deletePiece;
    public List<Piece> requirePieces;
}
