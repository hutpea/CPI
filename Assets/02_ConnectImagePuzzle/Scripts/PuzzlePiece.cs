using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IInitializePotentialDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private int puzzlePieceID;
    private Piece piece;

    private RectTransform rect;
    private RectTransform parent;
    private Canvas canvas;
    [SerializeField] private Vector2 originPosition;

    [SerializeField] private bool isCompleted = false;
    [SerializeField] private bool isDrag = false;

    private void Awake()
    {
        piece = GetComponent<Piece>();
        rect = GetComponent<RectTransform>();
        parent = transform.parent.GetComponent<RectTransform>();
    }

    private void Start()
    {
        canvas = GamePlayController.Instance.connectImagePuzzleGameplayController.gameMainCanvas;
    }

    public void Init(int id)
    {
        puzzlePieceID = id;
        originPosition = rect.anchoredPosition;
        Debug.Log("@LOG OriginPosition:" + originPosition);

        rect.localScale = new Vector2(0.85f, 0.85f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDrag || isCompleted) return;
        isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isCompleted) return;
        //Debug.Log(eventData.delta);
        //Debug.Log(canvas);
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        if (isCompleted) return;
        Vector2 endPoint = Vector2.zero;
        if (CheckPieceIsInRangeOfTarget(out endPoint))
        {
            isCompleted = true;
            piece.isCompleted = true;
            rect.DOKill();
            rect.DOScale(1f, 0.1f);
            rect.DOAnchorPos(endPoint, 0.25f).SetEase(Ease.Linear).OnComplete(delegate
            {

                CheckChangeLayer();
            });
        }
        else
        {
            rect.DOAnchorPos(originPosition, 0.225f).SetEase(Ease.OutQuad).OnComplete(delegate
            {
                isDrag = false;
            }); ;

        }
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        //eventData.useDragThreshold = false;
    }

    private bool CheckPieceIsInRangeOfTarget(out Vector2 targetPosition)
    {
        targetPosition = Vector2.zero;
        LevelData levelData = GamePlayController.Instance.connectImagePuzzleGameplayController.levelData;
        for (int i = 0; i < levelData.pieceTargetPositionDatas.Count; i++)
        {
            if (levelData.pieceTargetPositionDatas[i].positionIDs.Contains(this.puzzlePieceID) && Vector2.Distance(rect.anchoredPosition, levelData.pieceTargetPositionDatas[i].anchorPosition) < 250f)
            {
                //Debug.Log("IN range of target ID = " + this.puzzlePieceID);
                GamePlayController.Instance.connectImagePuzzleGameplayController.levelData.pieceTargetPositionDatas[i].hasPieceIn = true;
                targetPosition = levelData.pieceTargetPositionDatas[i].anchorPosition;
                return true;
            }
        }
        return false;
    }

    public void CheckOpenHiddenPieces()
    {
        var allHiddenRealgameData = GamePlayController.Instance.connectImagePuzzleGameplayController.allHiddenPieceRealgameData;
        foreach(var _hiddenRealgameData in allHiddenRealgameData)
        {
            bool isAllCompleted = true;
            foreach(var _piece in _hiddenRealgameData.requirePieces)
            {
                if(_piece.isCompleted == false)
                {
                    isAllCompleted = false;
                    break;
                }
            }
            if (isAllCompleted)
            {
                _hiddenRealgameData.hiddenPiece.ShowAllLayerElements(immediate: false);
            }
        }
    }

    public void CheckReplacePiece()
    {

    }

    public void CheckDeletePiece()
    {

    }

    private void CheckChangeLayer()
    {
        int currentLayer = GamePlayController.Instance.connectImagePuzzleGameplayController.currentPuzzleLayer;

        PuzzlePiece[] allPuzzlePieces = GameObject.FindObjectsOfType<PuzzlePiece>();
        foreach (PuzzlePiece puzzlePiece in allPuzzlePieces)
        {
            LayerElement firstLayerElement = puzzlePiece.transform.GetChild(0).GetComponent<LayerElement>();
            if (firstLayerElement.puzzleLayer == currentLayer && puzzlePiece.isCompleted == false)
            {
                return;
            }
        }
        currentLayer++;
        if (currentLayer > GamePlayController.Instance.connectImagePuzzleGameplayController.maxPuzzleLayer)
        {
            GameController.Instance.musicManager.PlayWinSound();
            GamePlayController.Instance.connectImagePuzzleGameplayController.Win();
            return;
        }
        GameController.Instance.musicManager.PlaySuccessLayerSound();
        GamePlayController.Instance.connectImagePuzzleGameplayController.currentPuzzleLayer = currentLayer;
        var allLayerElements = GamePlayController.Instance.connectImagePuzzleGameplayController.allLayerElements;
        foreach (var layerElement in allLayerElements)
        {
            if (layerElement.puzzleLayer == currentLayer)
            {
                layerElement.gameObject.SetActive(true);
                if (layerElement.gameObject.GetComponent<PuzzlePiece>() != null)
                {
                    layerElement.gameObject.GetComponent<RectTransform>().localScale = Vector3.zero;
                    layerElement.gameObject.GetComponent<RectTransform>().DOScale(0.8f, 0.3f);
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isCompleted) return;
        GameController.Instance.musicManager.PlayClickSound();
        rect.DOScale(1f, 0.2f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isCompleted) return;
        rect.DOScale(0.8f, 0.225f);
    }
}
