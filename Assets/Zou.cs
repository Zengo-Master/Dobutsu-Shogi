using UnityEngine;
using System.Collections;

public class Zou : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[4, 3];

        Chessman c;

        // Up Left
        if (CurrentY != 3)
        {
            if (CurrentX != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY + 1];
                if (c == null)
                {
                    r[CurrentX - 1, CurrentY + 1] = true;
                }
                else if (isWhite != c.isWhite)
                    r[CurrentX - 1, CurrentY + 1] = true;
            }
        }

        // Up Right
        if (CurrentY != 3)
        {
            if (CurrentX != 2)

            {
                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY + 1];
                if (c == null)
                {
                    r[CurrentX + 1, CurrentY + 1] = true;
                }
                else if (isWhite != c.isWhite)
                    r[CurrentX + 1, CurrentY + 1] = true;
            }
        }

        // Down Left
        if (CurrentY != 0)
        {
            if (CurrentX != 0)
            {
                //
                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY - 1];
                if (c == null)
                {
                    r[CurrentX - 1, CurrentY - 1] = true;
                }
                else if (isWhite != c.isWhite)
                    r[CurrentX - 1, CurrentY - 1] = true;
            }
        }

        // Down Right
        if (CurrentY != 0)
        {
            if (CurrentX != 2)
            {
                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY - 1];
                if (c == null)
                {
                    r[CurrentX + 1, CurrentY - 1] = true;
                }
                else if (isWhite != c.isWhite)
                    r[CurrentX + 1, CurrentY - 1] = true;
            }
        }

        return r;
    }

}
