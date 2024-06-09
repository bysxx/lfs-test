using UnityEngine;
using System.Collections.Generic;

public class PhoneNumber : MonoBehaviour
{
    // 맞춘 번호를 저장할 변수
    private List<int> currentNumber = new List<int>();

    // 정답 번호
    public int[] correctNumber = { 0, 3, 1, 3, 6, 9, 1, 6, 9, 4 };

    // 번호가 맞았을 때 호출할 이벤트
    public void OnDialNumber(int number)
    {
        currentNumber.Add(number);
        Debug.Log($"현재 번호 시퀀스: {string.Join("", currentNumber)}");

        if (currentNumber.Count == 10)
        {
            if (IsCorrectNumber())
            {
                Debug.Log("정답 번호 입력 완료!");
                GetComponentInChildren<QuestReporter>().Report(0);
            }
            else
            {
                Debug.Log("틀린 번호. 다시 시도하세요.");
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
