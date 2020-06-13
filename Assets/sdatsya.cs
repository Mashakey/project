using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sdatsya : MonoBehaviour
{
	
	public void ChangeScene(string sceneName)
	{
		if (BoardMeneger.isWiteTurn != true)
        {
			TempClass.win = 1;
        } else
        {
			TempClass.win = 0;
        }
		SceneManager.LoadScene(7);
	}
	public void Exit()
	{
		Application.Quit();
	}
	
}
