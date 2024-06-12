using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPComponent : MonoBehaviour, IHitable {

    public event Action<int> OnHPChanged;

    [SerializeField] private int hp;

    public void Hit(int dmg) {

        if (!GameManager.Instance.isTutorialCleared) return;
        
        hp -= dmg;

        OnHPChanged?.Invoke(hp < 0 ? 0 : hp);

        if (hp <= 0) {
            hp = 0;
            Dead();
        }
    }

    public void Dead() {
        Access.Player.StopPlayer();
        Access.UIM.FadeToScene("Review");
    }
}
