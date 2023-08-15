using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherSystem : MonoBehaviour
{
    private bool hasTether = false;
    [SerializeField] private GameObject tether;
    private GameObject currentTether;
    

    public void Tether(GameObject player)
    {
        if (hasTether)
        {
            Vector3 t = new Vector3(currentTether.transform.position.x + 1, currentTether.transform.position.y, currentTether.transform.position.z + 1);
            player.transform.position = t;
            hasTether = false;
            Destroy(currentTether);


        }
        else
        {
            Vector3 t = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z - 1);
            currentTether = Instantiate(tether, t, Quaternion.identity);
            hasTether = true;
        }
    }
}
