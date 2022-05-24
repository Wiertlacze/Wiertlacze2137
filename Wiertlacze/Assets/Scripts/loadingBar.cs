using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingBar : MonoBehaviour
{

    private Slider slider;
    float sliderValue;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = Random.Range(0, 2);
        slider.value += sliderValue * Time.deltaTime;
        if(slider.value == 1)
        {
            SceneManager.LoadScene(1);
        }
    }
}
