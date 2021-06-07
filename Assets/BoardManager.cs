using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance{set;get;}
    private bool[,] allowedMoves{set;get;}

    public Chessman[,] Chessmans{ set; get;}
    private Chessman selectedChessman;

    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    public List<GameObject> chessmanPrefabs;
    private List<GameObject> activeChessman;

    private Quaternion orientation = Quaternion.Euler(90,0,0);

    public bool isWhiteTurn = true;

    private void Start()
    {
        Instance = this;
        SpawnAllChessmans ();
    }

    void Update()
    {
        UpdateSelection ();
        DrawBoard ();

        if (Input.GetMouseButtonDown (0))
        // マウスがクリックされたときの処理
        {
            // 盤面内で
            if (selectionX >= 0 && selectionY >= 0)
            {
                // 駒が選択されていない
                if (selectedChessman == null)
                {
                    // 駒を持つ
                    SelectChessman(selectionX, selectionY);
                }
                else
                {
                    // 駒を動かす
                    MoveChessman(selectionX, selectionY);
                }
            }
        }
    }

    private void SelectChessman(int x,int y)
    {
        Debug.Log("駒を持つ");
        // 駒がない
        if (Chessmans [x, y] == null)
            return;
            Debug.Log("駒を持った");
        // 手番でない側の駒なら無効
        if(Chessmans [x,y].isWhite != isWhiteTurn)
            return;
            Debug.Log("駒を持っている");
        bool hasAtleastOneMove = false;
        allowedMoves = Chessmans [x, y].PossibleMove ();
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 3; j++) {
                Debug.Log(allowedMoves[i, j]);
                if (allowedMoves [i, j])
                    hasAtleastOneMove = true;
            }
        }
        Debug.Log(hasAtleastOneMove);
        if (!hasAtleastOneMove)
            return;
        
        selectedChessman = Chessmans [x, y];
        BoardHighlights.Instance.HighlightAllowedMoves (allowedMoves);
    }

    private void MoveChessman(int x,int y)
    {
        Debug.Log("着手");
        if (allowedMoves[x,y])
        {
            Chessman c = Chessmans [x, y];
            
            if (c != null && c.isWhite != isWhiteTurn)
            {
                // 駒を選択する

                // ライオンの場合
                if (c.GetType () == typeof(Lion))
                {
                    // 終了
                    Debug.Log("終了");
                    EndGame ();
                    return;
                }

                // 駒を取る
                activeChessman.Remove(c.gameObject);
                Destroy (c.gameObject);
            }

            Chessmans [selectedChessman.CurrentX, selectedChessman.CurrentY] = null;
            selectedChessman.transform.position = GetTileCenter (x, y);
            selectedChessman.SetPosition (x, y);
            Chessmans [x, y] = selectedChessman;
            isWhiteTurn = !isWhiteTurn;
        }

        BoardHighlights.Instance.Hidehighlights ();
        selectedChessman = null;
    }

    private void UpdateSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if (!Camera.main)
            return;

        RaycastHit hit;
        Debug.Log(Input.mousePosition);
        if(Physics.Raycast(ray, out hit,25.0f,LayerMask.GetMask("Plane")))
        { 
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }
        else {
            selectionX = -1;
            selectionY = -1;
        }
    }

    private void SpawnChessman(int index,int x, int y)
    {
        GameObject go = Instantiate (chessmanPrefabs [index], GetTileCenter(x,y), orientation) as GameObject;
        go.transform.SetParent (transform);
        Chessmans [x, y] = go.GetComponent<Chessman> ();
        Chessmans [x, y].SetPosition (x, y);
        activeChessman.Add (go);
    }

    private void SpawnAllChessmans()
    {
        activeChessman = new List<GameObject> ();
        Chessmans = new Chessman[3, 4];

        // ライオン
        SpawnChessman (0,1,0);

        // キリン
        SpawnChessman (1,2,0);

        // ゾウ
        SpawnChessman (2,0,0);

        // ひよこ
        SpawnChessman (3,1,1);

        // ライオン_
        SpawnChessman (5,1,3);

        // キリン_
        SpawnChessman (6,0,3);

        // ゾウ_
        SpawnChessman (7,2,3);

        // ひよこ_
        SpawnChessman (8,1,2);
    }

    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        return origin;
    }

    private void DrawBoard()
    {
        Vector3 widthLine = Vector3.right * 3;
        Vector3 heightLine = Vector3.forward * 4;

        for (int i = 0; i <= 4; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine (start, start + widthLine);
            for (int j = 0; j <= 3; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine (start, start + heightLine);
            }
        }

        // Draw the selection
        if (selectionX >= 0 && selectionY >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

            Debug.DrawLine(
                Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1));
        }
    }

    private void EndGame()
    {
        if (isWhiteTurn)
            Debug.Log("先手勝ち");
        else
            Debug.Log("後手勝ち");

        foreach (GameObject go in activeChessman)
            Destroy (go);

        isWhiteTurn = true;
        BoardHighlights.Instance.Hidehighlights ();
        SpawnAllChessmans ();
    }
}