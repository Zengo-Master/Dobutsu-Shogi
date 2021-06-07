using UnityEngine;
using System.Collections;

// public class Lion : Chessman
// {
//     public override bool[,] PossibleMove ()
//     {
//         bool[,] r = new bool[4, 3];

//         Chessman c;
//         int i, j;

//         // 上
//         i = CurrentX - 1;
//         j = CurrentY + 1;
//         if (CurrentY != 3)
//         {
//             for (int k = 0; k < 3; k++)
//             {
//                 if (i >= 0 || i < 3)
//                 {
//                     c = BoardManager.Instance.Chessmans [i, j];
//                     if (c == null)
//                         r [i, j] = true;
//                     else if (isWhite != c.isWhite)
//                         r [i, j] = true;
//                 }

//                 i++;
//             }
//         }

//         // 下
//         i = CurrentX - 1;
//         j = CurrentY - 1;
//         if (CurrentY != 0)
//         {
//             for (int k = 0; k < 3; k++)
//             {
//                 if (i >= 0 || i < 2)
//                 {
//                     c = BoardManager.Instance.Chessmans [i, j];
//                     if (c == null)
//                         r [i, j] = true;
//                     else if (isWhite != c.isWhite)
//                         r [i, j] = true;
//                 }

//                 i++;
//             }
//         }

//         // 左
//         if (CurrentX != 0)
//         {
//             c = BoardManager.Instance.Chessmans [CurrentX - 1, CurrentY];
//             if (c == null)
//                 r [CurrentX - 1, CurrentY] = true;
//             else if (isWhite != c.isWhite)
//                 r [CurrentX - 1, CurrentY] = true;
//         }

//         // 右
//         if (CurrentX != 2)
//         {
//             c = BoardManager.Instance.Chessmans [CurrentX + 1, CurrentY];
//             if (c == null)
//                 r [CurrentX + 1, CurrentY] = true;
//             else if (isWhite != c.isWhite)
//                 r [CurrentX + 1, CurrentY] = true;
//         }

//         return r;
//     }
// }

public class Lion : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[4, 3];

        Chessman c;

        // 左上
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

        // 右上
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

        // 上
        if (CurrentY != 3)
        {
            c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
            if (c == null)
                r[CurrentX, CurrentY + 1] = true;
            else if (isWhite != c.isWhite)
                r[CurrentX, CurrentY + 1] = true;
        }

        // 下
        if (CurrentY != 0)
        {
            c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
            if (c == null)
                r[CurrentX, CurrentY - 1] = true;
            else if (isWhite != c.isWhite)
                r[CurrentX, CurrentY - 1] = true;
        }


        // 左下
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

        // 右下
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

        // 左
        if (CurrentX != 0)
        {
            c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY];
            if (c == null)
                r[CurrentX - 1, CurrentY] = true;
                // エラー：IndexOutOfRangeException: Index was outside the bounds of the array.
            else if (isWhite != c.isWhite)
                r[CurrentX - 1, CurrentY] = true;
        }

        // 右
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
