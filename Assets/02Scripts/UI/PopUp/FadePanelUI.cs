using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanelUI : SceneUI
{

    private bool isBlack = true;
    private Animator animator;

    protected override void Init() {
        Canvas canvas = Utils.GetOrAddComponent<Canvas>(gameObject);
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.overrideSorting = true;
    }

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        Init();
        FadeInOut();
    }

    // black -> white
    private void FadeIn() {
        isBlack = false;
        animator.SetTrigger("FadeIn");
    }

    // white -> black
    private void FadeOut(string sceneName) {
        isBlack = true;
        animator.GetBehaviour<GoToSelectedScene>().sceneName = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void FadeInOut(string sceneName=null) {
        if (isBlack) FadeIn();
        else FadeOut(sceneName);
    }

}
