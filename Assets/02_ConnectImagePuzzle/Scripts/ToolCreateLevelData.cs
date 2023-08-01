#if UNITY_EDITOR
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class ToolCreateLevelData : MonoBehaviour
{
    public string levelPath;
    public Transform mainContainer;

    [Title("Level Information")]
    public int levelName;
    public List<HiddenPieceData> hiddenPieceData;
    public List<ReplacePieceData> replacePieceData;
    public List<DeletePieceData> deletePieceData;

    private List<PieceTargetPositionData> pieceTargetPositionDataList = new List<PieceTargetPositionData>();

    [Title("Level Data")]
    public LevelData levelData;

    [Button]
    public void InitExtraPieces()
    {
        hiddenPieceData = new List<HiddenPieceData>();
        foreach(Transform child in mainContainer)
        {
            Piece _piece = child.GetComponent<Piece>();
            if(_piece != null)
            {
                if(_piece.elementType == ElementType.HiddenPiece)
                {
                    HiddenPieceData _hiddenPieceData = new HiddenPieceData();
                    _hiddenPieceData.pieceID = _piece.pieceID;
                    hiddenPieceData.Add(_hiddenPieceData);
                }
                else if(_piece.elementType == ElementType.ReplacePiece)
                {
                    ReplacePieceData _replacePieceData = new ReplacePieceData();
                    _replacePieceData.pieceReplacedID = _piece.pieceID;
                    replacePieceData.Add(_replacePieceData);
                }
                else if (_piece.elementType == ElementType.DeletePiece)
                {
                    DeletePieceData _deletePieceData = new DeletePieceData();
                    _deletePieceData.pieceID = _piece.pieceID;
                    deletePieceData.Add(_deletePieceData);
                }
            }
        }
    }

    [Button]
    public void CreatePositionTarget()
    {
        levelData = new LevelData();
        pieceTargetPositionDataList = new List<PieceTargetPositionData>();
        PuzzlePiece[] puzzlePieces = GameObject.FindObjectsOfType<PuzzlePiece>();
        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            /*ImageElementData imageElementData = new ImageElementData();
            imageElementData.ID = puzzlePiece.gameObject.GetComponent<Image>().sprite.name;*/
            PieceTargetPositionData pieceTargetPositionData = new PieceTargetPositionData();
            pieceTargetPositionData.positionIDs = new List<int>();
            pieceTargetPositionData.positionIDs.Add(puzzlePiece.gameObject.GetComponent<Piece>().pieceID);
            pieceTargetPositionData.anchorPosition = puzzlePiece.gameObject.GetComponent<RectTransform>().anchoredPosition;
            pieceTargetPositionDataList.Add(pieceTargetPositionData);
        }
        levelData.pieceTargetPositionDatas = pieceTargetPositionDataList;
    }

    [Button]
    public void CreatePositionAllPieces()
    {
        string thisLevelPath = levelPath + "/Level_" + levelName + ".json";
        if (File.Exists(thisLevelPath))
        {
            ConfirmWindow.Init(OnRun, "Level_" + levelName + ".json");
            return;
        }
        OnRun();
        void OnRun()
        {
            List<PieceData> allPieceData = new List<PieceData>();
            foreach (Transform child in mainContainer)
            {
                Debug.Log("add " + child.name);
                PieceData pieceData = new PieceData();
                List<ImageElementData> imageElementDatas = new List<ImageElementData>();
                Piece pieceComponent = child.GetComponent<Piece>();
                if (pieceComponent == null)
                {
                    continue;
                }
                pieceData.pieceID = pieceComponent.pieceID;
                pieceData.elementType = pieceComponent.elementType;
                pieceData.anchorPosition = child.GetComponent<RectTransform>().anchoredPosition;
                pieceData.sizeDelta = child.GetComponent<RectTransform>().sizeDelta;

                foreach (Transform child2 in child)
                {
                    ImageElementData imageData = new ImageElementData();
                    imageData.imageID = child2.GetComponent<Image>().sprite.name;
                    imageData.puzzleLayer = child2.GetComponent<LayerElement>().puzzleLayer;
                    imageData.sortingLayer = child2.GetComponent<LayerElement>().sortingLayer;
                    imageData.anchorPosition = child2.GetComponent<RectTransform>().anchoredPosition;
                    imageData.sizeDelta = child2.GetComponent<RectTransform>().sizeDelta;
                    imageElementDatas.Add(imageData);
                }
                pieceData.imageData = imageElementDatas;
                allPieceData.Add(pieceData);
            }
            if (allPieceData.Count > 0)
            {
                Debug.Log(allPieceData.Count);
                levelData.pieceData = allPieceData;
            }
            if (hiddenPieceData.Count > 0)
                levelData.hiddenPieceData = hiddenPieceData;
            AnimLocation animLocation = FindObjectOfType<AnimLocation>();
            levelData.animSpawnLocation = animLocation.GetComponent<RectTransform>().anchoredPosition;

            string levelDataString = JsonUtility.ToJson(levelData, true);
            File.WriteAllText(thisLevelPath, levelDataString);
            Debug.Log("Create level " + levelName + " success !");
        }
    }
}

public class ConfirmWindow : EditorWindow
{
    private Action onYes;
    public string _levelName;
    public static void Init(Action onYes, string _levelName)
    {
        var box = GetWindow<ConfirmWindow>(true, "Confirm Save");
        //box.position = Rect.zero;
        box.minSize = new Vector2(250, 100);
        box.maxSize = new Vector2(250, 100);
        box.onYes = onYes;
        box._levelName = _levelName;
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("There exists json file named " + _levelName);
        GUIStyle greenBackgroundStyle = new GUIStyle(GUI.skin.button);
        greenBackgroundStyle.normal.background = MakeBackgroundTexture(200, 25, Color.green);
        greenBackgroundStyle.normal.textColor = Color.black;

        GUIStyle originalBackgroundStyle = new GUIStyle(GUI.skin.button);
        originalBackgroundStyle.normal.background = MakeBackgroundTexture(200, 25, Color.black);
        originalBackgroundStyle.normal.textColor = Color.white;

        if (GUILayout.Button("YES", greenBackgroundStyle) || (Event.current.isKey && Event.current.keyCode == KeyCode.Return))
        {
            onYes?.Invoke();
            this.Close();
        }
        if(GUILayout.Button("NO", originalBackgroundStyle))
        {
            this.Close();
        }
    }
    private void OnLostFocus()
    {
        Close();
    }
    private Texture2D MakeBackgroundTexture(int width, int height, Color color)
    {
        Color[] pixels = new Color[width * height];

        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = color;
        }

        Texture2D backgroundTexture = new Texture2D(width, height);

        backgroundTexture.SetPixels(pixels);
        backgroundTexture.Apply();

        return backgroundTexture;
    }

}

#endif