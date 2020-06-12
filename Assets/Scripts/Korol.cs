using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Korol : Chessmen
{
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];

		Chessmen c;
		int i, j;

		//Top Side
		i = CurrentX - 1;
		j = CurrentY + 1;
		if (CurrentY != 7)
		{
			for (int k = 0; k < 3; k++)
			{
				if (i >= 0 || i < 8)
				{
					c = BoardMeneger.Instance.Chessmens[i, j];
					if (c == null)
						r[i, j] = true;
					else if (isWite != c.isWite)
						r[i, j] = true;
				}

				i++;
			}
		}



		//Down Side
		i = CurrentX - 1;
		j = CurrentY - 1;
		if (CurrentY != 0)
		{
			for (int k = 0; k < 3; k++)
			{
				if (i >= 0 || i < 8)
				{
					c = BoardMeneger.Instance.Chessmens[i, j];
					if (c == null)
						r[i, j] = true;
					else if (isWite != c.isWite)
						r[i, j] = true;
				}

				i++;
			}
		}

		//Middle Left
		if (CurrentX != 0)
		{
			c = BoardMeneger.Instance.Chessmens[CurrentX - 1, CurrentY];
			if (c == null)
				r[CurrentX - 1, CurrentY] = true;
			else if (isWite != c.isWite)
				r[CurrentX - 1, CurrentY] = true;
		}

		//Middle Right
		if (CurrentX != 7)
		{
			c = BoardMeneger.Instance.Chessmens[CurrentX + 1, CurrentY];
			if (c == null)
				r[CurrentX + 1, CurrentY] = true;
			else if (isWite != c.isWite)
				r[CurrentX + 1, CurrentY] = true;
		}

		return r;
	}
}
