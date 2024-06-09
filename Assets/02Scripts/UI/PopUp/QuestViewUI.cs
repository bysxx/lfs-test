using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestViewUI : PopUpUI
{

    enum Buttons {
        ExiBtn
    }

    [SerializeField] private QuestListViewControllerUI questListViewController;
    [SerializeField] private QuestDetailViewUI questDetailView;

    protected override void Init() {
        base.Init();
    }

    private void Start()
    {

        Bind<Button>(typeof(Buttons));

        var questSystem = Access.QuestM;

        foreach (var quest in questSystem.ActiveQuests)
            AddQuestToActiveListView(quest);

        foreach (var quest in questSystem.CompletedQuests)
            AddQuestToCompletedListView(quest);

        questSystem.OnQuestRegisteredHandler += AddQuestToActiveListView;
        questSystem.OnQuestCompletedHandler += RemoveQuestFromActiveListView;
        questSystem.OnQuestCompletedHandler += AddQuestToCompletedListView;
        questSystem.OnQuestCompletedHandler += HideDetailIfQuestCanceled;
        questSystem.OnQuestCanceledHandler += HideDetailIfQuestCanceled;
        questSystem.OnQuestCanceledHandler += RemoveQuestFromActiveListView;

        foreach (var tab in questListViewController.Tabs)
            tab.onValueChanged.AddListener(HideDetail);

        GetButton((int)Buttons.ExiBtn).gameObject.BindEvent(OnExitBtnClicked);

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        var questSystem = Access.QuestM;
        if (questSystem)
        {
            questSystem.OnQuestRegisteredHandler -= AddQuestToActiveListView;
            questSystem.OnQuestCompletedHandler -= RemoveQuestFromActiveListView;
            questSystem.OnQuestCompletedHandler -= AddQuestToCompletedListView;
            questSystem.OnQuestCompletedHandler -= HideDetailIfQuestCanceled;
            questSystem.OnQuestCanceledHandler -= HideDetailIfQuestCanceled;
            questSystem.OnQuestCanceledHandler -= RemoveQuestFromActiveListView;
        }
    }

    private void OnEnable()
    {
        Init();
        if (questDetailView.Target != null) questDetailView.Show(questDetailView.Target);
    }

    private void ShowDetail(bool isOn, Quest quest)
    {
        if (isOn) questDetailView.Show(quest);
    }

    private void HideDetail(bool isOn)
    {
        questDetailView.Hide();
    }

    private void AddQuestToActiveListView(Quest quest)
        => questListViewController.AddQuestToActiveListView(quest, isOn => ShowDetail(isOn, quest));

    private void AddQuestToCompletedListView(Quest quest)
        => questListViewController.AddQuestToCompletedListView(quest, isOn => ShowDetail(isOn, quest));

    private void HideDetailIfQuestCanceled(Quest quest)
    {
        if (questDetailView.Target == quest) questDetailView.Hide();
    }

    private void RemoveQuestFromActiveListView(Quest quest)
    {
        questListViewController.RemoveQuestFromActiveListView(quest);
        if (questDetailView.Target == quest) questDetailView.Hide();
    }

    private void OnExitBtnClicked(PointerEventData data) {
        ClosePopUpUI();
    }
}
