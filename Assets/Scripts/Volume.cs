using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider mainSlider;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.Play();
        mainSlider.value = 1;
         mainSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void ValueChangeCheck()
    {
        audio.volume = mainSlider.value;
        Debug.Log(mainSlider.value);
    }
}
