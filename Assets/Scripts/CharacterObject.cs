using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterObject : MonoBehaviour
{

    protected virtual void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (spriteRenderer)
            spriteRenderer.transform.rotation = Camera.main.transform.rotation;
    }
}
