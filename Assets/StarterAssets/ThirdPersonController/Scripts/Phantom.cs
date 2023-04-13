using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gohst : MonoBehaviour
{
    bool GohstPower = false;
    public void wallNull(Collider collision)
    {
        if(collision.gameObject.tag == "Build4")
        {
            GohstPower = true;
        }

        if (GohstPower == true)
        {
            gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
