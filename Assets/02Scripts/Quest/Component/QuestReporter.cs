using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestReporter : MonoBehaviour
{
    [SerializeField]
    private Category[] category;
    [SerializeField]
    private TaskTarget target;
    [SerializeField]
    private int conditionCount;

    public void Report(int i)
    {
        Access.QuestM.ReceiveReport(category[i], target, conditionCount);
    }
}
