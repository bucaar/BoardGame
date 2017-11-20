using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpaceScript : MonoBehaviour {
    //the different types of GameSpace types we have
    public enum SpaceType
    {
        NEUTRAL,
        NEGATIVE
    }

    //the next possible route
    public GameObject[] next;

    //the default SpaceType for this GameSpace (public so we can change in unity editor)
    public SpaceType spaceType = SpaceType.NEUTRAL;
    
    //used for getting the sphere's material from the prefab
    //needs to be the child index of the sphere within the prefab
    private static int sphereIndex = 1;

    //this is the material of the sphere, used to change the color
    private Material spaceMaterial;

    //spaceColor property, depends on the type of space
    //readonly
    public Color spaceColor {
        get
        {
            switch (spaceType)
            {
                case SpaceType.NEUTRAL:     return Color.blue;
                case SpaceType.NEGATIVE:    return Color.red;
                default:                    return Color.white;
            }
        }
    }
    
    void Start () {
        //grab the sphere's material
        spaceMaterial = gameObject.transform.GetChild(sphereIndex).GetComponent<Renderer>().material;

        UpdateSpace();
	}
    
    private void UpdateSpace()
    {
        //update the color of the space
        spaceMaterial.color = spaceColor;
    }

    public void PlayerStopped(PlayerScript player)
    {
        print("Player landed");
    }

}
