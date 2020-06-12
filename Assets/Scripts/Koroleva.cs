using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koroleva : Chessmen
{
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];

		Chessmen c;
		int i, j;
		// Right
		i = CurrentX;
		while (true)
		{
			i++;
			if (i >= 8)
				break;
			c = BoardMeneger.Instance.Chessmens[i, CurrentY];
			if (c == null)
				r[i, CurrentY] = true;

			else
			{
				if (c.isWite != isWite)
					r[i, CurrentY] = true;

				break;
			}
		}

		// Left
		i = CurrentX;
		while (true)
		{
			i--;
			if (i < 0)
				break;

			c = BoardMeneger.Instance.Chessmens[i, CurrentY];
			if (c == null)
				r[i, CurrentY] = true;

			else
			{
				if (c.isWite != isWite)
					r[i, CurrentY] = true;

				break;
			}
		}

		// Up
		i = CurrentY;
		while (true)
		{
			i++;
			if (i >= 8)
				break;

			c = BoardMeneger.Instance.Chessmens[CurrentX, i];
			if (c == null)
				r[CurrentX, i] = true;

			else
			{
				if (c.isWite != isWite)
					r[CurrentX, i] = true;

				break;
			}
		}

		// Down
		i = CurrentY;
		while (true)
		{
			i--;
			if (i < 0)
				break;

			c = BoardMeneger.Instance.Chessmens[CurrentX, i];
			if (c == null)
				r[CurrentX, i] = true;

			else
			{
				if (c.isWite != isWite)
					r[CurrentX, i] = true;

				break;
			}
		}
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
