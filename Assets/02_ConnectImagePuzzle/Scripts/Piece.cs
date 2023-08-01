using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public int pieceID;
    public ElementType elementType;
    public List<LayerElement> layerElementList;
    public bool isCompleted = true;

    private void Awake()
    {
        layerElementList = new List<LayerElement>();
    }
    //public List<string> idList;
    [Button]
    public void SetThisPuzzlePiece()
    {
        if(GetComponent<PuzzlePiece>() == null)
        {
            gameObject.AddComponent<PuzzlePiece>();
        }
        elementType = ElementType.PuzzlePiece;
        transform.name = "PuzzlePiece";
    }

    public void ShowAllLayerElements(bool immediate = true)
    {
        foreach(LayerElement layer in layerElementList)
        {
            if(immediate)
                layer.gameObject.SetActive(true);
            else
            {
                Image layerImage = layer.GetComponent<Image>();
                Color color = layerImage.color;
                color.a = 0;
                layerImage.color = color;
                layer.gameObject.SetActive(true);
                layerImage.DOFade(1f, 0.25f);
            }
        }
    }
}