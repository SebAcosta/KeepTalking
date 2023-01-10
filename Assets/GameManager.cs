using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float startTime = 20;
    private float currentTime;
    public TMP_Text timerText;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public ParticleSystem particleSystem;
    public ParticleSystem winParticleSystem;
    public AudioSource audio;
    public AudioSource click;
    public AudioSource win;
    public AudioSource tick;
    private bool sono;
    private bool sono2;
    private bool sono3;
    private bool sono4;
    private bool isPlaying;
    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject boton4;
    public GameObject btnMain;
    public GameObject btnLado;
    public GameObject btnDisplay;
    private int touch;
    private float temp;

    void Start(){
        touch = 0;
        button1.onClick.AddListener(()=>TaskOnClick(1)); 
        button2.onClick.AddListener(()=>TaskOnClick(2)); 
        button3.onClick.AddListener(()=>TaskOnClick(3)); 
        button4.onClick.AddListener(()=>TaskOnClick(4));
        sono=false;
        sono2=false; 
        sono3=false;
        sono4=false; 
        isPlaying=false; 
        boton1.SetActive(true);
        boton2.SetActive(true);
        boton3.SetActive(true);
        boton4.SetActive(true);
        boton4.SetActive(true);
        btnMain.SetActive(true);
        btnLado.SetActive(true);
        btnDisplay.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime = Time.time;
        float timeLeft = startTime - currentTime;
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        if(isPlaying==false && timeLeft>2){
            Invoke("play",1.0f);
        }

        // Check if minutes is greater than the total number of minutes
        if (minutes > startTime / 60)
        {
            minutes = Mathf.FloorToInt(startTime / 60);
        }

        // Stop the timer when it reaches 0
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            minutes = 0;
            seconds = 0;
            //SetActive() = false;
            boton1.SetActive(false);
            boton2.SetActive(false);
            boton3.SetActive(false);
            boton4.SetActive(false);
            particleSystem.Emit(10);
            btnMain.SetActive(false);
            btnLado.SetActive(false);
            btnDisplay.SetActive(false);
            sono=true;
        }

        if(touch >= 4){
            if(touch==4){
                temp = timeLeft;
            }
            timeLeft = temp;
            winParticleSystem.Emit(2);
            Invoke("enable",1.0f);
            sono3=true;
        }

        if(sono3==true && sono4 == false){
            win.Play();
            sono4=true;
        }

        if(sono==true && sono2 == false){
            audio.Play();
            sono2=true;
        }

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void enable(){
        enabled = false;
    }

    public void play(){
        isPlaying=true;
        if(!(touch==4)){
            tick.Play();
        }
        Invoke("stop",1.0f);
    }

    public void stop(){
        isPlaying=false;
    }

    public void TaskOnClick(int btn)
    {
        if(btn == 1){
            Debug.Log("Boton1");
            click.Play();
            touch += 1;
        }
        if(btn == 2){
            click.Play();
            Debug.Log("Boton2");
            touch += 1;
        }
        if(btn == 3){
            click.Play();
            Debug.Log("Boton3");
            touch += 1;
        }
        if(btn == 4){
            click.Play();
            Debug.Log("Boton4");
            touch += 1;
        }
    }
}
