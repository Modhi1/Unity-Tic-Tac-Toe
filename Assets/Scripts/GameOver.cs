using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace SAMI.TICTACTOE.ModhiD
{
    public class GameOver : MonoBehaviour
    {
        public static GameOver instance;

        [SerializeField] private GameObject WinnerText;

        private void Awake()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            if (instance == null)
            {
                instance = this;
                return;
            }

            Destroy(gameObject);

        }


        public void ShowWinner(char winner)

        {
            // set the scale initally to be 0
            GetComponent<RectTransform>().localScale = Vector3.zero;

            string text = "";

            if (winner == 'T')

                text = "it's a TIE !!!";

            else
                text = "Winner is " + winner.ToString();

            // make the activator object active
            transform.GetChild(0).gameObject.SetActive(true);

            LeanTweenExt.LeanScale(gameObject, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutQuad).setDelay(0.2f);
            WinnerText.GetComponentInChildren<TextMeshProUGUI>().text = text;


        }



    }
}

