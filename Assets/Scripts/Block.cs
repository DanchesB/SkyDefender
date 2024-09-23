using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config params
    [SerializeField] AudioClip BreackSound;
    [SerializeField] GameObject blockSparklesVFX;    
    [SerializeField] Sprite[] hitSprites;
     
    //Cached reference
    Level level;

    //Sate variables
    [SerializeField] int timesHit;

    private void Start()
    {
       
        if(tag == "Breakable")
        {
             FindObjectOfType<Level>().CountBlocks();
        }       
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    public void DestroyBlock()
    {
       
        FindObjectOfType<GameSession>().AddToScore();               // »щем код под названием GameStatus, ссылаемс€ на метод AddToScore
        FindObjectOfType<Level>().BlockDestroyed();

        PlayBlockDestroySFX();                
        TriggerSparklesVFX();

        Destroy(gameObject);
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(BreackSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

}
