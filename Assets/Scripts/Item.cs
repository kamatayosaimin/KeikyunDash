using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : OtherObject
{
    [SerializeField] private int _score = 100;
    [SerializeField] private ParticleSystem _particle;

    protected abstract void PlayerHitChild(PlayerCharacter playerCharacter);

    protected sealed override void PlayerHit(PlayerCharacter playerCharacter)
    {
        playerCharacter.AddItemScore(_score);

        Instantiate(_particle, transform.position, Quaternion.identity);

        PlayerHitChild(playerCharacter);

        Destroy(gameObject);
    }
}
