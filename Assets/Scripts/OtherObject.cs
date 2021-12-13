using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OtherObject : CharacterObject
{
    protected abstract void PlayerHit(PlayerCharacter playerCharacter);

    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter playerCharacter = other.GetComponent<PlayerCharacter>();

        if (playerCharacter)
            PlayerHit(playerCharacter);
    }
}
