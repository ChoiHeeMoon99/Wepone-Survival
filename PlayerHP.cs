using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SeriallizeField]
    private float   maxHP=10;
    private float   currentHP;
    private SpriteRenderer  spriteRenderer;
    private PlayerController playerController;

    private void Awake()
    {
        currentHP=maxHP;
        spriteRenderer=GetComponent<spriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        currentHP-=damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if(currentHP<=0)
        {
            
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