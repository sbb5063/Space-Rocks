using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
   public GameObject restartPanel;
   public Text score;
   private bool lost;

   public void GameOver()
   {
       lost = true;
      Invoke("delay", 1f);
   }

   void delay()
   {
      restartPanel.SetActive(true);
   }
   
   
   public void Goto()
   {
       SceneManager.LoadScene("Level01");
   }

   public void Restart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

    public void MainMenu()
   {
       SceneManager.LoadScene("mainmenu");
   }

   public void Update()
   {
       if(lost == false)
       {
           score.text = Time.time.ToString("SCORE : 0");
   }   }
}
