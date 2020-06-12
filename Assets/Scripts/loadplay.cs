using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class loadplay : MonoBehaviour
{

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(5);
	}
	public void Exit()
	{
		Application.Quit();
	}
}
