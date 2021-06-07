using UnityEngine;
using System.Collections;

public class Kirin : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[4, 3];

        Chessman c;

        //Up
        if (CurrentY != 3)
        {
            c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
            if (c == null)
                r[CurrentX, CurrentY + 1] = true;
            else if (isWhite != c.isWhite)
                r[CurrentX, CurrentY + 1] = true;
        }

        //Down
        if (CurrentY != 0)
        {
            c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
            if (c == null)
                r[CurrentX, CurrentY - 1] = true;
            else if (isWhite != c.isWhite)
                r[CurrentX, CurrentY - 1] = true;
        }

        // Middle Left
        if (CurrentX != 0)
        {
            c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY];
            if (c == null)
                r[CurrentX - 1, CurrentY] = true;
            else if (isWhite != c.isWhite)
                r[CurrentX - 1, CurrentY] = true;
        }

        // Middle Right
        if (CurrentX != 2)
        {
            c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY];
            if (c == null)
                r[CurrentX + 1, CurrentY] = true;
            else if (isWhite != c.isWhite)
                r[CurrentX + 1, CurrentY] = true;
        }

        return r;
    }
}
