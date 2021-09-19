using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private float priceForStart = 100;

    [SerializeField] private List<SlotMachine> slotMachine;

    [SerializeField] private int[] pricePerMatch;

    private bool rewardIsGet = false;
    public void getReward()
    {
        if (!rewardIsGet)
        {
            countReward();
            rewardIsGet = true;
        }
    }
    private void countReward()
    {
        for (int s = 0; s < slotMachine.Count; s++)
            for (int n = 0; n < slotMachine[s].NumberOfMatches.Length; n++)
                for (int p = 1; p < pricePerMatch.Length; p++)
                    if (slotMachine[s].NumberOfMatches[n] == p) scoreCounter.add(pricePerMatch[p - 1]);
    }

    public void startPlay()
    {
        rewardIsGet = false;
        scoreCounter.takeAway(priceForStart);
    }
}
