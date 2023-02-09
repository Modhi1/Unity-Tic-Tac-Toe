using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SAMI.TICTACTOE.ModhiD
{


    public class SceneChanger : MonoBehaviour
    {

        public void PlayGameButtonClicked()
        {
            // a better way is to use index 
            SceneManager.LoadScene("SampleScene");
        }


        public void BackToMain()
        {
            // a better way is to use index 
            SceneManager.LoadScene("MenuScene");

        }


        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

}


