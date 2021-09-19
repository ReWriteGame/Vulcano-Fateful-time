using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private SlotVariant slotVariant;
    [SerializeField] private List<Slot> slotMachine;
    [SerializeField] private int[] numberOfMatches;

    public UnityEvent startSlotsEvent;
    public UnityEvent stopSlotsEvent;

    public int[] NumberOfMatches { get => numberOfMatches; private set => numberOfMatches = value; }

    private void Awake()
    {
        numberOfMatches = new int[slotVariant.IconSlot.Count];
    }



    private void countMatches()
    {
        clearArr();

        for (int v = 0; v < slotVariant.IconSlot.Count; v++)
            for (int m = 0; m < slotMachine.Count; m++)
                if (slotVariant.IconSlot[v] == slotMachine[m].CurrentIcon.sprite)
                    numberOfMatches[v]++; 
    }

    

    private void clearArr()
    {
        for (int n = 0; n < numberOfMatches.Length; n++)
            numberOfMatches[n] = 0;
    }

    public void startAllSlots()
    {
        startSlotsEvent?.Invoke();
        foreach (Slot slot in slotMachine)
            slot.startSlot();
    }
    public void stopAllSlots()
    {
        stopSlotsEvent?.Invoke();
        foreach (Slot slot in slotMachine)
            slot.StopAllCoroutines();

        countMatches();
    }


}
