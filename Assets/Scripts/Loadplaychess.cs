using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loadplaychess : MonoBehaviour
{

    public Slider slider;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((timer >= 1) && (timer <= 2))
        {
            slider.value = 25;
        }
        if ((timer >= 2) && (timer <= 4))
        {
            slider.value = 60;
        }
        if ((timer >= 4) && (timer <= 5))
        {
            slider.value = 85;
        }
        if ((timer >= 5) && (timer <= 6))
        {
            slider.value = 100;
        }
        if (timer >= 6)
        {
            SceneManager.LoadScene(6);
        }
    }

}
