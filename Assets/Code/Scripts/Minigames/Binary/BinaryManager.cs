using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryManager : MonoBehaviour
{
    public Binary binary;
    private List<BinaryLevel> binaryLevels = new List<BinaryLevel>();
    private int currentLevel = 0;
    private int currentHistory = 1;

    public class BinaryLevel
    {
        public int history { get; private set; }
        public int level { get; private set; }
        public int digitsCount { get; private set; }
        public List<int> blocksSecuence { get; private set; }
        public int minimumNumberOfClicks { get; private set; }

        public BinaryLevel(int history, int level, int digitsCount, List<int> blocksSecuence, int minimumNumberOfClicks)
        {
            if(ValidateParameters(digitsCount, blocksSecuence.Count, minimumNumberOfClicks))
            {
                this.history = history;
                this.level = level;
                this.digitsCount = digitsCount;
                this.blocksSecuence = blocksSecuence;
                this.minimumNumberOfClicks = minimumNumberOfClicks;
            }
        }

        private bool ValidateParameters(int digitsCount, int blocksSecuenceCount, int minimumNumberOfClicks)
        {
            int maxDigit = 12;
            bool validDigitsCount = digitsCount >= 0 && digitsCount <= maxDigit;
            bool validSecuenceBlocks = blocksSecuenceCount >= 1 ;
            bool validMinimumNumberOfClicks = minimumNumberOfClicks >= 1 && minimumNumberOfClicks <= digitsCount;

            return validDigitsCount && validSecuenceBlocks && validMinimumNumberOfClicks;
        }
    }

    private List<BinaryLevel> binaryLevelsOfTheActiveHistory = new List<BinaryLevel>();

    private void DetectLevelsOfTheActiveHistory() {
        foreach(BinaryLevel binaryLevel in binaryLevels)
            if(binaryLevel.history == currentHistory)
                binaryLevelsOfTheActiveHistory.Add(binaryLevel);
    }

    public void NextLevelOrFinishMinigame()
    {   
        if(binary.IsTargetValueReached())
        {
            if(currentLevel < binaryLevelsOfTheActiveHistory.Count)
            {
                binary.currentNumberOfClicks = 0;
                binary.SetupBinaryMinigame(binaryLevelsOfTheActiveHistory[currentLevel], binaryLevelsOfTheActiveHistory[currentLevel].minimumNumberOfClicks);
                currentLevel++;
                if(currentLevel != 1)
                    SoundBinaryManager.instance.PlayVictorySound();
                Debug.Log("CORRECTO");
            } else
            {
                Debug.Log("MINIJUEGO COMPLETADO");
            }
        } else
        {
            binary.WrongResponse(100);
            Debug.Log("INCORRECTO");
        }
        
    }

    private void InitializeHistoryLevels()
    {
        BinaryLevel history1level1 = new BinaryLevel(1, 1, 2, new List<int> { 0, 0, 0, 0, 1, 0, 0, 1, 0 }, 1);
        BinaryLevel history1level2 = new BinaryLevel(1, 2, 3, new List<int> { 1, 0, 0, 1, 0, 1, 0 ,1 }, 1);
        BinaryLevel history1level3 = new BinaryLevel(1, 3, 6, new List<int> { 1, 0, 0, 1, 0 , 0 }, 3);
        BinaryLevel history1level4 = new BinaryLevel(1, 4, 8, new List<int> { 1, 1, 0, 1, 1 }, 5);
        BinaryLevel history2level1 = new BinaryLevel(2, 1, 8, new List<int> { 0, 0, 0, 1, 1 }, 5);

        binaryLevels.Add(history1level1);
        binaryLevels.Add(history1level2);
        binaryLevels.Add(history1level3);
        binaryLevels.Add(history1level4);
        binaryLevels.Add(history2level1);
    }

    void Start()
    {
        InitializeHistoryLevels();
        DetectLevelsOfTheActiveHistory();
        NextLevelOrFinishMinigame();
        SoundBinaryManager.instance.PlayBinaryMusicSound();
    }
}
