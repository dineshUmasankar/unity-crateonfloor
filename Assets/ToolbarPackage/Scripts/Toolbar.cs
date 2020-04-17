using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Collision2DLab.UI
{
    public class Toolbar : MonoBehaviour
    {
        [HideInInspector]
        public bool isPlaying = false;
        public Text playPauseButtonText;

        // the commented out lines are for implementing the playing and pause functionality to other systems of the lab
        // just replace ContextMenu with whatever class you use for other systems and be sure to implement some bool like isPlaying on line 27
        //public ContextMenu cm1;

        private void Start()
        {
            Time.timeScale = 0f;
            playPauseButtonText.text = "Play";
        }

        private void Update()
        {
           // cm1.isPlaying = isPlaying;

            if (Input.GetKeyUp(KeyCode.Space))
            {
                TogglePause();
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                ResetLab();
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                SlowMo();
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                FastForward();
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Quit();
            }
        }

        public void TogglePause()
        {
            isPlaying = !isPlaying;

            Time.timeScale = !isPlaying ? 0f : 1f;
            playPauseButtonText.text = isPlaying ? "Pause" : "Play";
        }

        public void ResetLab()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        public void FastForward()
        {
            Time.timeScale *= Time.timeScale >= 2f ? 1f : 2f;
        }

        public void SlowMo()
        {
            Time.timeScale /= Time.timeScale <= 0.5f ? 1f : 2f;
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void OnTooltipEnter(GameObject tooltip)
        {
            tooltip.SetActive(true);
        }

        public void OnTooltipExit(GameObject tooltip)
        {
            tooltip.SetActive(false);
        }
    }
}
