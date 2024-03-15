using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SearchForPlayer : MonoBehaviour
{
    public string targetName = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(targetName))
        {
            var player = GameObject.Find(targetName);
            var agent = this.GetComponent<NavMeshAgent>();
            agent.destination = player.transform.position;
        }
    }
}
