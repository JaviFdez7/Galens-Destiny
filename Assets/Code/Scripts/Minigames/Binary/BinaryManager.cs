using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryManager : MonoBehaviour
{
    public Binary binary;
    List<BinaryLevel> binaryLevels = new List<BinaryLevel>(); // Se crean todos los binary levels, se añaden a la lista y se pasan al binary.cs
    private int currentLevel = 0;
    private int currentHistory = 1;

    public class BinaryLevel
    {
        public int history { get; private set; }
        public int level { get; private set; }
        public int digitsCount { get; private set; }
        public int whiteBlocks { get; private set; }
        public int blackBlocks { get; private set; }
        public int minimumNumberOfClicks { get; private set; }

        public BinaryLevel(int history, int level, int digitsCount, int whiteBlocks, int blackBlocks, int minimumNumberOfClicks)
        {
            if(ValidateParameters(digitsCount, whiteBlocks, blackBlocks, minimumNumberOfClicks))
            {
                this.history = history;
                this.level = level;
                this.digitsCount = digitsCount;
                this.whiteBlocks =  whiteBlocks;
                this.blackBlocks = blackBlocks;
                this.minimumNumberOfClicks = minimumNumberOfClicks;
            }
        }

        private bool ValidateParameters(int digitsCount, int whiteBlocks, int blackBlocks, int minimumNumberOfClicks)
        {
            int maxDigit = 12;
            bool validDigitsCount = digitsCount>=0 && digitsCount<=maxDigit;
            bool validWhiteBlocks = whiteBlocks>=0;
            bool validBlackBlocks = blackBlocks>=0;
            bool validMinimumNumberOfClicks = minimumNumberOfClicks>=1 && minimumNumberOfClicks<=digitsCount;

            return validDigitsCount && validWhiteBlocks && validBlackBlocks && validMinimumNumberOfClicks;
        }
    }

    public void NextLevelOrFinishMinigame()
    {   
        if(binary.IsTargetValueReached())
        {
            if(currentLevel == 0)
            {

            } else if(true)
            {

            }
            else{

            }
        } else
        {
            Debug.Log("INCORRECTO");
        }
        
    }

    private void Initialize()
    {
        BinaryLevel history1level1 = new BinaryLevel(1, 1, 2, 1, 0, 1);
        BinaryLevel history1level2 = new BinaryLevel(1, 2, 3, 1, 0, 1);
        BinaryLevel history1level3 = new BinaryLevel(1, 3, 6, 1, 0, 3);
        BinaryLevel history1level4 = new BinaryLevel(1, 4, 8, 1, 0, 5);

        binaryLevels.Add(history1level1);
        binaryLevels.Add(history1level2);
        binaryLevels.Add(history1level3);
        binaryLevels.Add(history1level4);
    }

    void Start()
    {
        Initialize();
    }
}
