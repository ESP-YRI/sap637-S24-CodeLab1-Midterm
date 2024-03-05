using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    private SpriteRenderer npcSprite;
    public PolygonCollider2D npcCollider;
    public Sprite bloodPool;
    public Sprite pacified;
    
    // Start is called before the first frame update
    void Start()
    {
        npcSprite = GetComponent<SpriteRenderer>();
        npcCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "Killed")
        {
            npcSprite.sprite = bloodPool;
            npcCollider.isTrigger = true;
        }

        if (tag == "Spared")
        {
            npcSprite.sprite = pacified;
            npcCollider.isTrigger = true;
        }
    }
}
