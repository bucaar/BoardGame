using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour {
    //id counter, every player gets a unique id
    private static int id = 0;

    //array of player colors
    private static Color[] playerColors = {
        new Color(.5f, .5f, 1f),
        new Color(1f, .5f, .5f),
        new Color(.5f, 1f, .5f)
    };

    //the furthest distance to allow a new destination
    public float distanceThreshold = .2f;
    
    //the current player's id
    private int myId;

    //the material component, used for setting the color
    private Material myMaterial;

    //The NavMeshAgent used for finding a route to the next space.
    private NavMeshAgent myAgent;

    //This is the number of spaces left on the dice
    private int spacesLeftToMove = 0;

    //whether or not we are currently moving
    private bool moving = false;

    //the current space we are standing on (or the one we are walking towards if moving is true)
    public GameObject currentGameSpace;
    
	void Start () {
        //get the components
        myMaterial = GetComponent<Renderer>().material;
        myAgent = GetComponent<NavMeshAgent>();

        //assign our id
        myId = id++;

        //and give some sweet colors
        myMaterial.color = playerColors[myId % playerColors.Length];
	}

    void Update()
    {
        //calculate a random dice roll
        if (Input.GetKeyDown(KeyCode.Space) && spacesLeftToMove == 0 && !moving)
        {
            spacesLeftToMove = Random.Range(1, 7);
            print("You rolled a " + spacesLeftToMove);

            moving = true;
        }
        
        //we are moving and we are close enough to our target
        if(moving && myAgent.remainingDistance < distanceThreshold)
        {
            //get the script for the current space, we will either be moving or notifying that we are done moving
            AbstractGameSpace currentGameSpaceScript = currentGameSpace.GetComponent<AbstractGameSpace>();

            //if we still have spaces to move
            if (spacesLeftToMove > 0)
            {
                //see the possible next spaces to go to
                GameObject[] nextSpaces = currentGameSpaceScript.nextPossibleSpaces;
                if (nextSpaces.Length > 0)
                {
                    //TODO: give the user a choice on which path to take
                    //assume path 0
                    GameObject nextSpace = nextSpaces[0];
                    //set the destination of the agent
                    myAgent.SetDestination(nextSpace.transform.position);

                    //set our current game space to the choice
                    currentGameSpace = nextSpace;
                    //and decrease our spaces left to move (dice block)
                    spacesLeftToMove -= 1;
                }
            }
            else
            {
                //we are moving, remaining distance is small, and no more spaces to move.
                //that means we are done moving!
                currentGameSpaceScript.PlayerLanded(this);
                moving = false;
            }
        }
    }
}
