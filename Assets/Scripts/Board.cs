using System;
using UnityEngine;
using UnityEngine.UI;


namespace SAMI.TICTACTOE.ModhiD
{
    public class Board : MonoBehaviour
    {
        #region Variables
        // static to make it accessable from anywhere & only 1 copy 
        public static Board instance;

        private static bool player1;

        [SerializeField] private Sprite spriteO;
        [SerializeField] private Sprite spriteX;

        private Char playerType = 'V';

        // array of char representing X & O
        private Char[,] symbolsArray = new Char[3, 3];

        private int numOfAvailableCellss;

        #endregion
        private void Awake()
        {
            player1 = true;
            if (instance == null)
            {
                instance = this;
                return;
            }

            Destroy(gameObject);

        }

        private void Start()
        {

            int no_of_rows = symbolsArray.GetLength(0);
            int no_of_columns = symbolsArray.GetLength(1);

            numOfAvailableCellss = no_of_rows * no_of_columns;
            // populating the array with a start value (-)
            for (int row = 0; row < no_of_rows; row++)
            {
                for (int column = 0; column < no_of_columns; column++)
                {
                    symbolsArray[row, column] = '-';
                }
            }
        }

        public void ButtonClickedOnBoard(CellPlacement button, Vector2Int pos)
        {

           
                int row = (int)pos.x;
                int colunm = (int)pos.y;

                // reduce number of avaliavle cells 
                numOfAvailableCellss--;
                // playerType = X or O
                ChangePlayerType();

                // Assign button value (X or O) to the symbolsArray, taking into consideration the button position
                symbolsArray[row, colunm] = playerType;

                // Update the button text based on the player type (X or O), with some styling 
                UpdateButtonImage(button);

                // Disable button 
                button.enabled = false;

                // Check if the player (X or O) has won 
                CheckWin(row, colunm);

                // Change turns between X and O
                player1 = !player1;


        }
        // method that change turns & returns the player type 
        public void ChangePlayerType()
        {

            if (player1)
            {
                playerType = 'X';
            }

            else
            {
                playerType = 'O';

            }


        }

        private void UpdateButtonImage(CellPlacement button)
        {
            Image buttonImage = button.GetComponent<Image>();

            if (playerType.Equals('X'))
            {
                buttonImage.sprite = spriteX;
                button.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            }
            else if (playerType.Equals('O'))
            {
                buttonImage.sprite = spriteO;

            }

        }

        private void CheckWin(int row, int colunm)
        {
            // 1- check row -> Match? call GameOver | No Match?
            // 2- check colunm -> Match? call GameOver | No Match?
            // 3- check if diagonal -> Match? call method | No Match?
            // 4- check if counter diagonal -> Match? call method | No Match?
            // 5- check available cells
            bool win = false;
            int rowSize = symbolsArray.GetLength(0);
            int sumOfRowAndCol = row + colunm;
            win = CheckRows(row, colunm);

            if (!win)
            {

                win = CheckColunms(row, colunm);

                if (!win)
                {
                    // check if the cell (button) diagonal
                    if (row == colunm)
                    {
                        win = CheckDiagonals(row, colunm);

                    }
                    // check if the cell (button) counter diagonal
                    if (!win && (sumOfRowAndCol == (rowSize - 1)))
                    {
                        win = CheckCounterDiagonals(row, colunm);
                    }

                    // after win is set by diagonal || counter diagonal 
                    if (!win)
                    {
                        bool movesLeft = CheckBoardStatus();

                        if (movesLeft)
                        {
                            return;
                        }
                        else
                        {
                            // call gameOver script with 'T', indicating a tie 
                            GameOver.instance.ShowWinner('T');
                            return;
                        }
                    }
                }

            }

            GameOver.instance.ShowWinner(playerType);


        }

        private Boolean CheckRows(int row, int colunm)
        {
            int count = 0;
            int no_of_columns = symbolsArray.GetLength(1);


            //  the row is constant and the colunm is changing 

            // always start the search from the first colunm & the clicked button row
            for (int i = 0; i < no_of_columns; i++)
            {
                // empty spot -> no need to search the row 
                if (symbolsArray[row, i].Equals('-'))
                    return false;

                if (symbolsArray[row, i].Equals(playerType))
                {
                    count++;
                }
                else
                {
                    // not the same type (X or O) so return false
                    return false;
                }

            }
            // found match of 3
            if (count == no_of_columns)
            {
                return true;
            }

            else
            {
                return false;

            }
        }

        private Boolean CheckColunms(int row, int colunm)
        {
            // loop the entire colunm by changing the row
            int count = 0;
            int no_of_rows = symbolsArray.GetLength(0);

            // always start the search from the first row & the clicked button colunm
            for (int i = 0; i < no_of_rows; i++)
            {

                // empty spot -> no need to search the row 
                if (symbolsArray[i, colunm].Equals('-'))
                    return false;

                if (symbolsArray[i, colunm].Equals(playerType))
                {
                    count++;
                }
                else
                {
                    // not the same type (X or O) so return false
                    return false;
                }
            }

            // found match 
            if (count == no_of_rows)
            {
                return true;
            }

            else
            {
                return false;

            }


        }

        private Boolean CheckDiagonals(int row, int colunm)
        {
            int count = 0;
            int no_of_columns = symbolsArray.GetLength(1);

            for (int i = 0; i < no_of_columns; i++)
            {
                // empty spot -> no need to search the row 
                if (symbolsArray[i, i].Equals('-'))
                    return false;

                if (symbolsArray[i, i].Equals(playerType))
                {
                    count++;
                }
                else
                {
                    // not the same type (X or O) so return false
                    return false;
                }
            }

            // found match of 3
            if (count == no_of_columns)
            {
                return true;
            }

            else
            {
                return false;

            }
        }

        private Boolean CheckCounterDiagonals(int row, int colunm)
        {
            int count = 0;
            int no_of_columns = symbolsArray.GetLength(1);
            int size = no_of_columns - 1;
            for (int i = 0; i < no_of_columns; i++)
            {

                // empty spot -> no need to search the row 
                if (symbolsArray[i, size].Equals('-'))
                    return false;

                if (symbolsArray[i, size].Equals(playerType))
                {
                    count++;
                }
                else
                {
                    // not the same type (X or O) so return false
                    return false;
                }

                size -= 1;
            }

            // found match of 3
            if (count == no_of_columns)
            {
                return true;
            }

            else
            {
                return false;

            }
        }

        private Boolean CheckBoardStatus()
        {


            if (numOfAvailableCellss == 0)
                return false;

            return true;
        }

      
    }


}
