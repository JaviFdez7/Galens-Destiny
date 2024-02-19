using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static BinaryManager;

public class Binary : MonoBehaviour 
{
    public BinaryScore binaryScore;
    public DigitNumbersLayout digitNumbersLoyout;
    public BlockLayout blockLayout;
    private int currentValue = 0;
    private int targetValue;
    private List<int> binaryNumbers = new List<int>();
    public List<DigitPanel> digitPanels;
    public TextMeshProUGUI currentValueText;
    public TextMeshProUGUI targetValueText;
    private int currentNumberOfClicks = 0;
    private int minimumNumberOfClicksInTheActiveHistory;

    private void SetupBinaryMinigame(BinaryLevel binaryLevel, int minimumNumberOfClicksInTheActiveHistory)
    {
        targetValue = GenerateRandomTarget(binaryLevel); // Generate a random target
        InitializeBinaryNumbers(binaryLevel); // Initialize current value respect to the generated random target and the binary level configuration
        digitNumbersLoyout.BuildDigitsGrid(binaryLevel.digitsCount, binaryNumbers, digitPanels); // Build the digits grid with the generated current value 
        blockLayout.InitializeBlockPanel(binaryLevel.blocksSecuence);
        for(int i = 0; i < digitPanels.Count; i++){
            int reversedIndex = binaryNumbers.Count - 1 - i;
            UpdateDigitsPanel(i, reversedIndex);
        }
        UpdateUIElement();
        this.minimumNumberOfClicksInTheActiveHistory = minimumNumberOfClicksInTheActiveHistory; 
        binaryScore.CalculateCurrentScore(minimumNumberOfClicksInTheActiveHistory, currentNumberOfClicks);
    }

    // Generate Target -------------------------------------------------------------
    private int GenerateRandomTarget(BinaryLevel binaryLevel)
    {
        string binaryString = GenerateRandomBinaryString(binaryLevel.digitsCount);
        int decimalNumber = Convert.ToInt32(binaryString, 2);
        return decimalNumber;
    }

    private string GenerateRandomBinaryString(int length)
    {
        System.Random random = new System.Random();
        char[] binaryArray = new char[length];

        for (int i = 0; i < length; i++)
            binaryArray[i] = (random.Next(2) == 0) ? '0' : '1';

        return new string(binaryArray);
    }

    // Generate initial binary number -------------------------------------------------------------
    private void InitializeBinaryNumbers(BinaryLevel binaryLevel)
    {
        System.Random random = new System.Random();
        List<int> randomDifferentPositions = new List<int>();

        while(randomDifferentPositions.Count < binaryLevel.minimumNumberOfClicks)
        {
            int randomNumber = random.Next(0, binaryLevel.digitsCount);
            if(!randomDifferentPositions.Contains(randomNumber))
                randomDifferentPositions.Add(randomNumber);
        }

        List<int> targetBinaryNumber = ConvertToBinaryList(targetValue, binaryLevel);

        for (int i = 0; i < binaryLevel.digitsCount; i++)
        {
            if(randomDifferentPositions.Contains(i))
                binaryNumbers.Add(targetBinaryNumber[i] == 0? 1 : 0);
            else
                binaryNumbers.Add(targetBinaryNumber[i]);
        }

        string binaryString = string.Concat(binaryNumbers.ConvertAll(num => num.ToString()));
        int decimalNumber = Convert.ToInt32(binaryString, 2);
        currentValue = decimalNumber;

        for (int i = 0; i < binaryLevel.digitsCount; i++)
        {
            if(targetBinaryNumber[i] != binaryNumbers[i])
                Debug.Log("CAMBIA LA POSICIÓN "+ i);
        }
    }

    private List<int> ConvertToBinaryList(int number, BinaryLevel binaryLevel)
    {
        List<int> binaryList = new List<int>();
        while (number > 0)
        {
            binaryList.Add(number % 2);
            number /= 2;
        }
        while (binaryList.Count < binaryLevel.digitsCount)
            binaryList.Add(0);
        binaryList.Reverse();
        return binaryList;
    }

    // Changing a digit binary value from current value -------------------------------------------
    public void ChangeDigitBinaryValue(int index)
    {
        currentNumberOfClicks++;
        int reversedIndex = binaryNumbers.Count - 1 - index;
        binaryNumbers[reversedIndex] = binaryNumbers[reversedIndex] == 0 ? 1 : 0;
        string binaryString = string.Concat(binaryNumbers.ConvertAll(num => num.ToString()));
        int decimalNumber = Convert.ToInt32(binaryString, 2);
        currentValue = decimalNumber;
        blockLayout.NextBlockPanelStep();
        UpdateDigitsPanel(index, reversedIndex);
        UpdateUIElement();
        binaryScore.CalculateCurrentScore(minimumNumberOfClicksInTheActiveHistory, currentNumberOfClicks);
    }

    private void UpdateDigitsPanel(int index, int reversedIndex)
    {
        foreach(DigitPanel digitPanel in digitPanels)
        {
            if(digitPanel.index == index)
                digitPanel.UpdateDigitPanel(binaryNumbers[reversedIndex].ToString());
        }
    }

    // Check target value ----------------------------------------------------
    public bool IsTargetValueReached()
    {
        return currentValue == targetValue;
    }

    public void CheckTargetValue()
    {
        if(IsTargetValueReached())
        {
            Debug.Log("CORRECTO");
        } else
        {
            Debug.Log("INCORRECTO");
        }
    }

    // Update visual elements ----------------------------------------------------

    private void UpdateUIElement()
    {
        currentValueText.text = currentValue.ToString();
        targetValueText.text = targetValue.ToString();
    }
    void Start()
    {
         SetupBinaryMinigame(new BinaryLevel(1, 1, 7, new List<int> { 1, 0}, 2), 2); 
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
