using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float   maxHP=10;
    private float   currentHP;
    private SpriteRenderer  spriteRenderer;
    private PlayerController playerController;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP=maxHP;
        spriteRenderer=GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        currentHP-=damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // 체력이 0이하 = 플레이어 캐릭터 사망
        if(currentHP<=0)
        {
            //체력이 0이면 OnDie() 함수를 호출해서 죽었을 떄 처리한다
            playerController.OnDie();
        }
    }
    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color=Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color=Color.white;
    }
}