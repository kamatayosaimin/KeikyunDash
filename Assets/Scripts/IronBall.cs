using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBall : OtherObject
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected override void PlayerHit(PlayerCharacter playerCharacter)
    {
        playerCharacter.Dead();
    }
}
