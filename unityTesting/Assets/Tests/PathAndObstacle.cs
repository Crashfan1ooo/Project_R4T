using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class PathAndObstacle
{

    GameObject npc;
    GameObject goal;
    float distance;
    float minDist;
    float roto;

    // A Test behaves as an ordinary method
    [SetUp]
    public void Setup()
    {
        npc = GameObject.Find("NPC");
        goal = GameObject.Find("Goal");
        minDist = 1f;
        distance = 1000f;
        roto = 1.5f;
        
       
    }

    [Test]
    public void NPCArrivedAtGoal()
    {
        Assert.AreEqual(npc.transform.position, goal.transform.position);
        //Everything in the next few slides
        //will go between these curly brackets
    }

    public void PathAndObstacleSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
 

    [UnityTest]
    public IEnumerator NPCTakesPathToGoal()
    {
        while (distance > minDist)
        {

            Vector3 targetposition = goal.transform.position - npc.transform.position;
            // Vector3.RotateTowards(goal.transform.position, npc.transform.position, 1f, 1f);

            Vector3 newDirection = Vector3.RotateTowards(Vector3.forward, targetposition, 1.0f, 0.0f);




            npc.transform.Translate(Vector3.forward * Time.deltaTime);

            distance = Vector3.Distance(goal.transform.position, npc.transform.position);

            Debug.Log("Yo I'm Live" + npc.transform.position);

            yield return null;
        }

        Assert.Less(distance, minDist);

        yield return null;
    }

}
