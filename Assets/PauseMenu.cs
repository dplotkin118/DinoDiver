using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour  {

        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public AudioMixer mixer;
        public static float volumeLevel = 1.0f;
        private Slider sliderVolumeCtrl;
        public GameObject controlsButton;

        void Awake (){
                SetLevel (volumeLevel);
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
        }

        void Start (){
                pauseMenuUI.SetActive(false);
        }

        void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                  Debug.Log(GameisPaused);
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
        }

        void Pause(){
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
                controlsButton.SetActive(true);
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void Restart(){
                Time.timeScale = 1f;
                //restart the game:
                Globals.bones_count = 0;
                Globals.gems_count = 0;
                Globals.isBought = false;
                Globals.isBought2 = false;
                Globals.isBought3 = false;
                Globals.isBought4 = false;
                Globals.isBought5 = false;
                Globals.isBought6 = false;
                Globals.isBought8 = false;
                //Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene ("Game");
        }

        public void QuitGame(){
                Debug.Log("Quitting Game...");
                Application.Quit();
        }

        public void SetLevel (float sliderValue){
                mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                volumeLevel = sliderValue;
        }
}
