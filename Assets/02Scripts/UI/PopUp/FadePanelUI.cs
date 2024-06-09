using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanelUI : SceneUI
{

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
        FadeIn();
    }

    // black -> white
    public void FadeIn() {
        animator.SetTrigger("FadeIn");
    }

    // white -> black
    public void FadeOut() {
        animator.SetTrigger("FadeToScene");
    }

    // white -> black
    public void FadeToScene(string sceneName) {
        animator.GetBehaviour<GoToSelectedScene>().sceneName = sceneName;
        animator.SetTrigger("FadeToScene");
    }

}
