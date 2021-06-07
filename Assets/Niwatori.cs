using UnityEngine;
using System.Collections;

public class Niwatori : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[4, 3];

        if (isWhite)
        {

            Chessman c;

            // Up Left
            if (CurrentY != 3)
            {
                if (CurrentX != 0)
                {
                    //
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
        }

        else
        {

            Chessman c;

            // Op Up Left
            if (CurrentY != 0)
            {
                if (CurrentX != 3)
                {
                    //
                    c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY - 1];
                    if (c == null)
                    {
                        r[CurrentX + 1, CurrentY - 1] = true;
                    }
                    else if (isWhite != c.isWhite)
                        r[CurrentX + 1, CurrentY - 1] = true;
                }
            }

            // Op Up Right
            if (CurrentY != 0)
            {
                if (CurrentX != 0)

                {
                    c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY - 1];
                    if (c == null)
                    {
                        r[CurrentX - 1, CurrentY - 1] = true;
                    }
                    else if (isWhite != c.isWhite)
                        r[CurrentX - 1, CurrentY - 1] = true;
                }
            }

            // Op Up
            if (CurrentY != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                if (c == null)
                    r[CurrentX, CurrentY - 1] = true;
                else if (isWhite != c.isWhite)
                    r[CurrentX, CurrentY - 1] = true;
            }

            // Op Down
            if (CurrentY != 3)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                if (c == null)
                    r[CurrentX, CurrentY + 1] = true;
                else if (isWhite != c.isWhite)
                    r[CurrentX, CurrentY + 1] = true;
            }

            // Op Middle Left
            if (CurrentX != 2)
            {
                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY];
                if (c == null)
                    r[CurrentX + 1, CurrentY] = true;
                else if (isWhite != c.isWhite)
                    r[CurrentX + 1, CurrentY] = true;
            }

            // Op Middle Right
            if (CurrentX != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY];
                if (c == null)
                    r[CurrentX - 1, CurrentY] = true;
                else if (isWhite != c.isWhite)
                    r[CurrentX - 1, CurrentY] = true;
            }
        }
        return r;
    }
}
