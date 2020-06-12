using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slon : Chessmen
{
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];

		Chessmen c;
		int i, j;

		//Top Left
		i = CurrentX;
		j = CurrentY;
		while (true)
		{
			i--;
			j++;
			if (i < 0 || j >= 8)
				break;

			c = BoardMeneger.Instance.Chessmens[i, j];
			if (c == null)
				r[i, j] = true;
			else
			{
				if (isWite != c.isWite)
					r[i, j] = true;
				break;
			}
		}

		//Top Right
		i = CurrentX;
		j = CurrentY;
		while (true)
		{
			i++;
			j++;
			if (i >= 8 || j >= 8)
				break;

			c = BoardMeneger.Instance.Chessmens[i, j];
			if (c == null)
				r[i, j] = true;
			else
			{
				if (isWite != c.isWite)
					r[i, j] = true;
				break;
			}
		}

		//Down Left
		i = CurrentX;
		j = CurrentY;
		while (true)
		{
			i--;
			j--;
			if (i < 0 || j < 0)
				break;

			c = BoardMeneger.Instance.Chessmens[i, j];
			if (c == null)
				r[i, j] = true;
			else
			{
				if (isWite != c.isWite)
					r[i, j] = true;
				break;
			}
		}

		//Down Right
		i = CurrentX;
		j = CurrentY;
		while (true)
		{
			i++;
			j--;
			if (i >= 8 || j < 0)
				break;

			c = BoardMeneger.Instance.Chessmens[i, j];
			if (c == null)
				r[i, j] = true;
			else
			{
				if (isWite != c.isWite)
					r[i, j] = true;
				break;
			}
		}

		return r;
	}
}
