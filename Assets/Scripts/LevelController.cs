using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LevelController : Singleton<LevelController>
    {
        [SerializeField] private GameObject congratsText;
        [SerializeField] private Button speechButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private AudioSource audio;
        
        [SerializeField] private GameObject targets1;
        [SerializeField] private GameObject targets2;
        [SerializeField] private GameObject objects1;
        [SerializeField] private GameObject objects2;
        private int greenCounter;

        public void IncrementGreen()
        {
            greenCounter++;
            if (greenCounter == 3)
            {
                congratsText.SetActive(true);
                greenCounter = 0;
                if(targets1.activeInHierarchy)
                    nextButton.gameObject.SetActive(true);
            }
        }

        public void DecrementGreen()
        {
            greenCounter--;
            if (greenCounter < 0)
            {
                greenCounter = 0;
            }
        }

        private void PlayTaskTrack()
        {
            audio.Play();
        }

        private void OnEnable()
        {
            speechButton.onClick.AddListener(PlayTaskTrack);
            nextButton.onClick.AddListener(NextLevelOn);
        }

        private void NextLevelOn()
        {
            targets1.SetActive(false);
            objects1.SetActive(false);
            targets2.SetActive(true);
            objects2.SetActive(true);
            greenCounter = 0;
            congratsText.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            speechButton.onClick.RemoveListener(PlayTaskTrack);
            nextButton.onClick.RemoveListener(NextLevelOn);
        }
    }
}