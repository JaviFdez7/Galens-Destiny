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
    private List<int> targetBinaryNumber = new List<int>();
    public List<DigitPanel> digitPanels;
    public TextMeshProUGUI currentValueText;
    public TextMeshProUGUI targetValueText;
    public int currentNumberOfClicks = 0;
    private int minimumNumberOfClicksInTheActiveLevel;
    public TextMeshProUGUI currentNumberOfClicksText;
    public TextMeshProUGUI minimumNumberOfClicksInTheActiveLevelText;
    public BinaryChat binaryChat;

    public void SetupBinaryMinigame(BinaryLevel binaryLevel, int minimumNumberOfClicksInTheActiveLevel)
    {
        digitNumbersLoyout.DestroyDigitsGrid();
        blockLayout.DestroyBlockGrid();
        binaryNumbers.Clear();
        targetValue = GenerateRandomTarget(binaryLevel); // Generate a random target
        InitializeBinaryNumbers(binaryLevel); // Initialize current value respect to the generated random target and the binary level configuration
        digitNumbersLoyout.BuildDigitsGrid(binaryLevel.digitsCount, binaryNumbers, digitPanels); // Build the digits grid with the generated current value 
        blockLayout.InitializeBlockPanel(binaryLevel.blocksSecuence);
        for(int i = 0; i < digitPanels.Count; i++){
            int reversedIndex = binaryNumbers.Count - 1 - i;
            UpdateDigitsPanel(i, reversedIndex);
        }
        this.minimumNumberOfClicksInTheActiveLevel = minimumNumberOfClicksInTheActiveLevel; 
        binaryScore.CalculateCurrentScore(minimumNumberOfClicksInTheActiveLevel, currentNumberOfClicks);
        binaryChat.SetupBinaryChat(binaryScore, CorrectAnswer());
        UpdateUIElement();
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

        targetBinaryNumber = ConvertToBinaryList(targetValue, binaryLevel);

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
        binaryScore.CalculateCurrentScore(minimumNumberOfClicksInTheActiveLevel, currentNumberOfClicks);
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

    public void WrongResponse(int negativePoints)
    {
        binaryScore.SubstractPoints(negativePoints);
    }
    

    // Update visual elements ----------------------------------------------------

    private void UpdateUIElement()
    {
        currentValueText.text = currentValue.ToString();
        targetValueText.text = targetValue.ToString();
        currentNumberOfClicksText.text = currentNumberOfClicks.ToString();
        minimumNumberOfClicksInTheActiveLevelText.text = minimumNumberOfClicksInTheActiveLevel.ToString();
    }

    // Question auxiliar functions ----------------------------------------------------

    private string CorrectAnswer()
    {
        string result = "";
        for (int i = 0; i < targetBinaryNumber.Count; i++)
        {
            result += targetBinaryNumber[i].ToString();
        }

        return result;
    }
}


