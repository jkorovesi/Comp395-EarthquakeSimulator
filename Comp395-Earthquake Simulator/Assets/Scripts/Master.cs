using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Master : MonoBehaviour {
	private float min = 2.0f;
	private float max = 3.0f;

    public GameObject menuCanvas;
    public GameObject gameCanvas;
    public GameObject wtfCanvas;
    public GameObject plane;

    public Slider magSlider;
    public Slider durSlider;

    public Text magSliderText;
    public Text durSliderText;
    public Text magGameText;
    public Text durGameText;
    public Text wtfMagText;
    public Text wtfDurText;

    public AudioClip sec10;
    public AudioClip sec20;
    public AudioClip menu;
    public AudioClip inGameSong;
    public AudioClip sanicSong;

    AudioSource sanicBG;
    AudioSource inGame;
    AudioSource eqSound;
    AudioSource menuMusic;

    public Button begin;
    public Button reset;
    public Button wtf;

    public Image sanic;

    public RectTransform sky;

    public Light lightSource;

	public float magnitude;
    public float duration;
    public float wtfValue = 0;

	// Use this for initialization
	void Start () {
        
        
        //Begin the game
        begin.onClick.AddListener(() =>
        {
            menuCanvas.SetActive(false);
            gameCanvas.SetActive(true);
            menuMusic.Stop();
            OnMagnitudeEnter();
            inGame.PlayOneShot(inGameSong);
            duration = durSlider.value * 10;

        });

        //Reset the Game
        reset.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        });

        //wtf
        wtf.onClick.AddListener(() =>
        {
            wtfValue = 1;
            menuCanvas.SetActive(false);            
            wtfCanvas.SetActive(true);
            menuMusic.Stop();
            sanicBG.PlayOneShot(sanicSong);
            duration = durSlider.value * 10;
        });

        //Musical Stuff
        eqSound = GetComponent<AudioSource>();
        menuMusic = GetComponent<AudioSource>();
        inGame = GetComponent<AudioSource>();
        sanicBG = GetComponent<AudioSource>();
        menuMusic.PlayOneShot(menu);

        // Plane Limits
        min = plane.transform.position.x;
		max = plane.transform.position.x + 3;

        //wtf
        
	}
	
	// Update is called once per frame
	void Update () {

        /*----------------------------------------------- */
        //Text Stuff

        //Magnitude Stuff
        
        magnitude = magSlider.value;
        magSliderText.text = magSlider.value.ToString();
        magGameText.text = "Magnitude: " + magSlider.value.ToString();
        wtfMagText.text = "mAGniTuDEE: SANIC";


        //Duration Stuff
        if (durSlider.value == 1 && wtfValue == 0)
        {
            durSliderText.text = "Short";
            durGameText.text = "Duration: " + "Short";
        } else
        {
            durSliderText.text = "Long";
            durGameText.text = "Duration: " + "Long";
        }
            wtfDurText.text = "Duration: " + "INFINITY";
            for (int i = 0; i < 100; i++) {
                wtfDurText.text = wtfDurText.text + "Y";
            }




        /*----------------------------------------------- */

        //In-Game stuff

        if (menuCanvas.activeInHierarchy == false)
        {  
            plane.SetActive(true);

            if (duration >= 0)
                duration -= Time.deltaTime;
                plane.transform.position = new Vector3 (Mathf.PingPong (Time.time * magnitude, max - min) + min, plane.transform.position.y, plane.transform.position.z);
        }

        /*----------------------------------------------- */

        //wtf stuff
        if (menuCanvas.activeInHierarchy == false && wtfValue == 1 )
        {
            plane.SetActive(true);
            plane.transform.position = new Vector3(Mathf.PingPong(Time.time * 100, max - min) + min, plane.transform.position.y, plane.transform.position.z);
            lightSource.color = Color.cyan;
            sky.rotation = Quaternion.Euler(0, 0, 300 * Time.time);
            //sanic.transform.position = new Vector3(Screen.height, 0, Screen.width);
        }

        /*----------------------------------------------- */
    }

    //In-Game Music
    void OnMagnitudeEnter()
    {
        if (durSlider.value == 1)
        {
            eqSound.PlayOneShot(sec10);
        } else
        {
            eqSound.PlayOneShot(sec20);
        }
    }

}
