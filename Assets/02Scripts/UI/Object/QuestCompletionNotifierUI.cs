using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using System.Reflection;

public class QuestCompletionNotifierUI : ObjectUI {
    enum TMPs {
        TitleText,
        RewardText
    }

    [SerializeField] private string titleDescription;
    [SerializeField] private float showTime = 3f;

    private Queue<Quest> reservedQuests = new Queue<Quest>();
    private StringBuilder stringBuilder = new StringBuilder();

    private void Start()
    {

        var questSystem = Access.QuestM;
        questSystem.OnQuestCompletedHandler += Notify;
        questSystem.OnAchievementCompletedHandler += Notify;

        Bind<TextMeshProUGUI>(typeof(TMPs));

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        var questSysem = Access.QuestM;
        if (questSysem != null)
        {
            questSysem.OnQuestCompletedHandler -= Notify;
            questSysem.OnAchievementCompletedHandler -= Notify;
        }
    }

    private void Notify(Quest quest)
    {
        reservedQuests.Enqueue(quest);

        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            StartCoroutine("ShowNotice");
        }
    }

    private IEnumerator ShowNotice()
    {
        var waitSeconds = new WaitForSeconds(showTime);

        Quest quest;
        while (reservedQuests.TryDequeue(out quest))
        {
            GetTMP((int)TMPs.TitleText).text = titleDescription.Replace("%{dn}", quest.DisplayName);
            foreach (var reward in quest.Rewards)
            {
                stringBuilder.Append(reward.Description);
                stringBuilder.Append(" ");
                stringBuilder.Append(reward.Quantity);
                stringBuilder.Append(" ");
            }
            GetTMP((int)TMPs.RewardText).text = stringBuilder.ToString();
            stringBuilder.Clear();

            yield return waitSeconds;
        }

        gameObject.SetActive(false);
    }
}
