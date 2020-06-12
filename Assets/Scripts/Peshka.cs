using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peshka : Chessmen
{
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];
		Chessmen c, c2;
		int[] e = BoardMeneger.Instance.EnPassantMove;

		//White team move
		if (isWite)
		{
			//Diagonal Left
			if (CurrentX != 0 && CurrentY != 7)
			{
				if (e[0] == CurrentX -1 && e [1] == CurrentY + 1)
					r[CurrentX - 1, CurrentY + 1] = true;
			
				c = BoardMeneger.Instance.Chessmens[CurrentX - 1, CurrentY + 1];
				if (c != null && !c.isWite)
					r[CurrentX - 1, CurrentY + 1] = true;
			}

			//Diagonal Right
			if (CurrentX != 7 && CurrentY != 7)
			{
				if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
					r[CurrentX + 1, CurrentY + 1] = true;

				c = BoardMeneger.Instance.Chessmens[CurrentX + 1, CurrentY + 1];
				if (c != null && !c.isWite)
					r[CurrentX + 1, CurrentY + 1] = true;
			}

			//Middle
			if (CurrentY != 7)
			{
				c = BoardMeneger.Instance.Chessmens[CurrentX, CurrentY + 1];
				if (c == null)
					r[CurrentX, CurrentY + 1] = true;
			}

			//Middle on first move
			if (CurrentY == 1)
			{
				c = BoardMeneger.Instance.Chessmens[CurrentX, CurrentY + 1];
				c2 = BoardMeneger.Instance.Chessmens[CurrentX, CurrentY + 2];
				if (c == null & c2 == null)
					r[CurrentX, CurrentY + 2] = true;
			}
		}

		else
		{

			//Diagonal Left
			if (CurrentX != 0 && CurrentY != 0)
			{
				if (e[0] == CurrentX - 1 && e[1] == CurrentY - 1)
					r[CurrentX - 1, CurrentY - 1] = true;

				c = BoardMeneger.Instance.Chessmens[CurrentX - 1, CurrentY - 1];
				if (c != null && c.isWite)
					r[CurrentX - 1, CurrentY - 1] = true;
			}

			//Diagonal Right
			if (CurrentX != 7 && CurrentY != 0)
			{
				if (e[0] == CurrentX + 1 && e[1] == CurrentY - 1)
					r[CurrentX + 1, CurrentY - 1] = true;

				c = BoardMeneger.Instance.Chessmens[CurrentX + 1, CurrentY - 1];
				if (c != null && c.isWite)
					r[CurrentX + 1, CurrentY - 1] = true;
			}

			//Middle
			if (CurrentY != 0)
			{
				c = BoardMeneger.Instance.Chessmens[CurrentX, CurrentY - 1];
				if (c == null)
					r[CurrentX, CurrentY - 1] = true;
			}

			//Middle on first move
			if (CurrentY == 6)
			{
				c = BoardMeneger.Instance.Chessmens[CurrentX, CurrentY - 1];
				c2 = BoardMeneger.Instance.Chessmens[CurrentX, CurrentY - 2];
				if (c == null & c2 == null)
					r[CurrentX, CurrentY - 2] = true;
			}

		}

		return r;
	}
}
