using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeGameSpace : AbstractGameSpace {

    public override void SpaceStart()
    {

    }

    public override void SpaceUpdate()
    {

    }

    public override void PlayerLanded(PlayerScript player)
    {
        base.PlayerLanded(player);

        Debug.Log("-3 coins");
    }
}
