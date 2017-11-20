using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGameSpace : MonoBehaviour {
     
    //the next possible spaces to go to
    public GameObject[] nextPossibleSpaces;

    //these are used to visualize the type of space we have
    //by setting the color of the material to spaceBehavior.Color
    public Renderer spaceRenderer;

    //the color of the space
    private Color color;
    public virtual Color Color {
        get
        {
            return color;
        }
        set
        {
            //set the color
            color = value;

            //display the appropriate color
            spaceRenderer.material.color = color;
        }
    }

    public abstract void SpaceStart();

    public abstract void SpaceUpdate();

    public virtual void PlayerLanded(PlayerScript player)
    {
        Debug.Log("Player landed on a " + Color.ToString() + " space");
    }

    //unity specific
    void Start() {
        //initialize the Color property
        Color = spaceRenderer.material.color;
        //call custom virtual method
        SpaceStart();
    }
    
    void Update() {
        //call custom virtual methoD
        SpaceUpdate();
    }

}
