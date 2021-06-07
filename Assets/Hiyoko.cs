using UnityEngine;
using System.Collections;

public class Hiyoko : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[9, 9];
        Chessman c;

        // 自分の動き
        if (isWhite)
        {
            if (CurrentY == -1)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 3; j++)
                        if (BoardManager.Instance.Chessmans[i, j] == null)
                            r[i, j] = true;

            }
            else
            {
                // 前に進む
                if (CurrentY != 4)
                {
                    c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                    if (c == null)
                        r[CurrentX, CurrentY + 1] = true;
                    else if (isWhite != c.isWhite)
                        r[CurrentX, CurrentY + 1] = true;
                }
            }
        }
        else
        {
            if (CurrentY == -1)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 1; j < 3; j++)
                        if (BoardManager.Instance.Chessmans[i, j] == null)
                            r[i, j] = true;

            }
            // 相手の動き
            else
            {
                if (CurrentY != 0)
                {
                    c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                    if (c == null)
                        r[CurrentX, CurrentY - 1] = true;
                    else if (isWhite != c.isWhite)
                        r[CurrentX, CurrentY - 1] = true;
                }
            }
        }

        return r;
    }
}
