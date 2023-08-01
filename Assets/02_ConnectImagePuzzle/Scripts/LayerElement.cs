using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerElement : MonoBehaviour
{
    public int puzzleLayer;
    public int sortingLayer;

    public void Init(ElementType pieceElementType, int puzzleLayer, int sortingLayer)
    {
        this.puzzleLayer = puzzleLayer;
        //Debug.Log(this.puzzleLayer);
        this.sortingLayer = sortingLayer;

        Canvas canvas = gameObject.AddComponent<Canvas>();
        GraphicRaycaster graphicRaycaster = gameObject.AddComponent<GraphicRaycaster>();

        canvas.worldCamera = Camera.main;
        canvas.overrideSorting = true;
        canvas.sortingLayerName = "LayerElement";
        canvas.sortingOrder = this.sortingLayer;

        if (this.puzzleLayer != 1 || pieceElementType == ElementType.HiddenPiece)
        {
            gameObject.SetActive(false);
        }
    }

    [Button]
    public void SetRectTransformSizeEqualImage()
    {
        Image image = GetComponent<Image>();
        RectTransform rect = GetComponent<RectTransform>();
        rect.sizeDelta = image.sprite.textureRect.size;
    }

    [Button]
    public void SetCanvasLayer()
    {
        Canvas layerCanvas = GetComponent<Canvas>();
        layerCanvas.sortingLayerName = "LayerElement";
        layerCanvas.sortingOrder = this.sortingLayer;
    }
}