using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public GameObject Pause;
   public void Playgame()
   {
      Time.timeScale = 1;
      SceneManager.LoadScene(1);
      //AudioManager.instance.PlayBackgroundMusic();
   }
   public void Pauser()
   {
      Time.timeScale = 0;
      Pause.SetActive(true);
      AudioManager.instance.StopBackgroundMusic();
   }
   public void Choitiep()
   {
      Time.timeScale = 1;
      Pause.SetActive(false);
      AudioManager.instance.PlayBackgroundMusic();
   }
   public void homegame()
   {
      SceneManager.LoadScene(0);
   }
}
