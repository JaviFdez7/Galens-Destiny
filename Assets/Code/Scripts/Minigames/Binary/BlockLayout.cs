using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockLayout : MonoBehaviour
{
    public GameObject whiteBlockPrefab;
    public GameObject blackBlockPrefab;
    public GridLayoutGroup blockGridPanel;
    private List<int> blocksSequence = new List<int>();
    private int currentPointer;

    public void InitializeBlockPanel(List<int> sequence)
    {
        while (blocksSequence.Count < 14)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if(sequence[i] == 0)
                    blocksSequence.Add(0);
                else
                    blocksSequence.Add(1);
            }
        }

        currentPointer = 3;
        
        for(int i = 0; i < 7; i++)
        {
            if (blocksSequence[i] == 0)
                Instantiate(whiteBlockPrefab, blockGridPanel.transform);
            else
                Instantiate(blackBlockPrefab, blockGridPanel.transform);
        }        
    }

    public void NextBlockPanelStep()
    {
        currentPointer++;

        foreach (Transform child in blockGridPanel.transform)
            Destroy(child.gameObject);

        int sequenceLength = blocksSequence.Count;
        int startIndex = currentPointer - 3;
        int endIndex = currentPointer + 3;

        for (int i = startIndex; i <= endIndex; i++)
        {
            int index = (i + sequenceLength) % sequenceLength;
            if (blocksSequence[index] == 0)
                Instantiate(whiteBlockPrefab, blockGridPanel.transform);
            else
                Instantiate(blackBlockPrefab, blockGridPanel.transform);
        }
    }

    public void DestroyBlockGrid()
    {
        foreach (Transform child in blockGridPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
