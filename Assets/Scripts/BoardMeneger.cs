﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class BoardMeneger : MonoBehaviour
{
	public float param = 1;
	public float whiteTime;
	public float blackTime;
	public Text second1;
	public Text second2;


	public static BoardMeneger Instance { set; get; }
	private bool[,] allowedMoves { set; get; }

	public Chessmen[,] Chessmens { set; get; }
	private Chessmen selectedChessmen;

	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSET = 0.5f;

	private int selectionX = -1;
	private int selectionY = -1;

	public List<GameObject> chessmanPrefabs;
	private List<GameObject> activeChessman = new List<GameObject>();

	private Material previousMat;
	public Material selectedMat;

	public int[] EnPassantMove { set; get; }

	private Quaternion orientation = Quaternion.Euler(-90, -90, 0);
	private Quaternion orientation2 = Quaternion.Euler(-90, -90, 180);

	public static bool isWiteTurn = true;
	private void Start()
	{
		
		whiteTime = TempClass.settimer*60;
		blackTime = TempClass.settimer*60;
		Instance = this;
		SpawnAllChesmans();
	}

	private void Update()
	{
		param -= Time.deltaTime;
		if (param <= 0)
		{
			param = 1;
			if (isWiteTurn == true)
			{
				if (whiteTime > 1)
				{
					whiteTime--;
				}
				else
				{
					TempClass.win = 1;
					SceneManager.LoadScene(7);
				}
			}
			if (isWiteTurn == false)
			{
				if (blackTime > 1)
				{
					blackTime--;
				}
				else
				{
					TempClass.win = 0;
					SceneManager.LoadScene(7);
				}
			}
		}

		second1.text = Convert.ToString(whiteTime);
		second2.text = Convert.ToString(blackTime);
		UpdateSelection();
		DrawChessboard();

		if (Input.GetMouseButtonDown(0))
		{
			if (selectionX >= 0 && selectionY >= 0)
			{
				if (selectedChessmen == null)
				{
					//Select the Chessmen
					SelectChessmen(selectionX, selectionY);
				}
				else
				{
					//Move the Chessmen
					MoveChessmen(selectionX, selectionY);
				}
			}
		}
	}
	private void SelectChessmen(int x, int y)
	{
		if (Chessmens[x, y] == null)
			return;

		if (Chessmens[x, y].isWite != isWiteTurn)
			return;

		bool hasAtLeastOneMove = false;
		allowedMoves = Chessmens[x, y].PossibleMove();
		for (int i = 0; i < 8; i++)
			for (int j = 0; j < 8; j++)
				if (allowedMoves[i, j])
					hasAtLeastOneMove = true;
		if (!hasAtLeastOneMove)
			return;


		allowedMoves = Chessmens[x, y].PossibleMove();
		selectedChessmen = Chessmens[x, y];
		previousMat = selectedChessmen.GetComponent<MeshRenderer>().material;
		selectedMat.mainTexture = previousMat.mainTexture;
		selectedChessmen.GetComponent<MeshRenderer>().material = selectedMat;
		BoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
	}
	private void MoveChessmen(int x, int y)
	{
		if (allowedMoves[x, y])
		{
			Chessmen c = Chessmens[x, y];

			if (c != null && c.isWite != isWiteTurn)
			{
				//Caprure a piece

				//If it is a king
				if (c.GetType() == typeof(Korol))
				{
					EndGame();
					return;
				}

				activeChessman.Remove(c.gameObject);
				Destroy(c.gameObject);
			}

			if (selectedChessmen.GetType () == typeof(Peshka))
			{
				if (y == 7)
				{
					activeChessman.Remove(selectedChessmen.gameObject);
					Destroy(selectedChessmen.gameObject);
					SpawnChessman(1, x, y);
					selectedChessmen = Chessmens[x, y];
				}
				else if (y == 0)
				{
					activeChessman.Remove(selectedChessmen.gameObject);
					Destroy(selectedChessmen.gameObject);
					SpawnChessman(7, x, y);
				}
			}


			Chessmens[selectedChessmen.CurrentX, selectedChessmen.CurrentY] = null;
			selectedChessmen.transform.position = GetTileCenter(x, y);
			selectedChessmen.SetPosition(x, y);
			Chessmens[x, y] = selectedChessmen;
			isWiteTurn = !isWiteTurn;
		}

		selectedChessmen.GetComponent<MeshRenderer>().material = previousMat;
		BoardHighlights.Instance.Hidenhighlights();
		selectedChessmen = null;
	}

	private void SpawnChessman(int index, int x, int y)
	{
		GameObject go;
		if (y == 7)
		{ go = Instantiate(chessmanPrefabs[index], GetTileCenter(x, y), orientation2) as GameObject; }
		else
		{ go = Instantiate(chessmanPrefabs[index], GetTileCenter(x, y), orientation) as GameObject; }
		go.transform.SetParent(transform);
		Chessmens[x, y] = go.GetComponent<Chessmen>();
		Chessmens[x, y].SetPosition(x, y);
		activeChessman.Add(go);
	}



	private void UpdateSelection()
	{
		if (!Camera.main)
			return;

		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
		{
			selectionX = (int)hit.point.x;
			selectionY = (int)hit.point.z;
		}
		else
		{
			selectionX = -1;
			selectionY = -1;
		}
	}
	private void SpawnAllChesmans()
	{
		activeChessman = new List<GameObject>();
		Chessmens = new Chessmen[8, 8];
		EnPassantMove = new int[2] { -1, -1 };

		//Spawn the white team!
		//King
		SpawnChessman(0, 3, 0);

		//Queen
		SpawnChessman(1, 4, 0);

		//Rooks
		SpawnChessman(2, 0, 0);
		SpawnChessman(2, 7, 0);

		//Bishops
		SpawnChessman(3, 2, 0);
		SpawnChessman(3, 5, 0);

		//Knights
		SpawnChessman(4, 1, 0);
		SpawnChessman(4, 6, 0);

		//Pawns
		for (int i = 0; i < 8; i++)
			SpawnChessman(5, i, 1);

		//Spawn the black team!
		//King
		SpawnChessman(6, 4, 7);

		//Queen
		SpawnChessman(7, 3, 7);

		//Rooks
		SpawnChessman(8, 0, 7);
		SpawnChessman(8, 7, 7);

		//Bishops
		SpawnChessman(9, 2, 7);
		SpawnChessman(9, 5, 7);

		//Knights
		SpawnChessman(10, 1, 7);
		SpawnChessman(10, 6, 7);

		//Pawns
		for (int i = 0; i < 8; i++)
			SpawnChessman(11, i, 6);
	}

	private Vector3 GetTileCenter(int x, int z)
	{
		Vector3 origin = Vector3.zero;
		origin.x += (TILE_SIZE * x) + TILE_OFFSET;
		origin.z += (TILE_SIZE * z) + TILE_OFFSET;
		return origin;
	}

	private void DrawChessboard()
	{
		Vector3 widthLine = Vector3.right * 8;
		Vector3 heigthLine = Vector3.forward * 8;

		for (int i = 0; i <= 8; i++)
		{
			Vector3 start = Vector3.forward * i;
			Debug.DrawLine(start, start + widthLine);
			for (int j = 0; j <= 8; j++)
			{
				start = Vector3.right * j;
				Debug.DrawLine(start, start + heigthLine);
			}
		}
		//Draw the selection
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
		if (isWiteTurn)
        {
			TempClass.win = 0;
			SceneManager.LoadScene(7);
		}
		else
        {
			TempClass.win = 1;
			SceneManager.LoadScene(7);
		}
	}
}


