using UnityEngine;
using System.Collections.Generic;

public class PhoneNumber : MonoBehaviour
{
    // ���� ��ȣ�� ������ ����
    private List<int> currentNumber = new List<int>();

    // ���� ��ȣ
    public int[] correctNumber = { 0, 3, 1, 3, 6, 9, 1, 6, 9, 4 };

    // ��ȣ�� �¾��� �� ȣ���� �̺�Ʈ
    public void OnDialNumber(int number)
    {
        currentNumber.Add(number);
        Debug.Log($"���� ��ȣ ������: {string.Join("", currentNumber)}");

        if (currentNumber.Count == 10)
        {
            if (IsCorrectNumber())
            {
                Debug.Log("���� ��ȣ �Է� �Ϸ�!");
                GetComponentInChildren<QuestReporter>().Report(0);
            }
            else
            {
                Debug.Log("Ʋ�� ��ȣ. �ٽ� �õ��ϼ���.");
                currentNumber.Clear();
            }
        }
    }

    private bool IsCorrectNumber()
    {
        for (int i = 0; i < 10; i++)
        {
            if (currentNumber[i] != correctNumber[i])
            {
                return false;
            }
        }
        return true;
    }
}
