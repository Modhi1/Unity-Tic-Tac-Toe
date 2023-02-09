using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace SAMI.TICTACTOE.ModhiD
{
    public class CellPlacement : MonoBehaviour
    {

        [SerializeField] private Vector2Int position;

        // public static CellPlacement instance;


        public void CellClicked()
        {

            // call method in Board script and send the position and the script (this)
            // so you can access the button

            Board.instance.ButtonClickedOnBoard(this, position);

        }
    }

}
