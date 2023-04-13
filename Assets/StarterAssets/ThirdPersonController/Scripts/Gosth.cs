using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gosth : MonoBehaviour
{
    [SerializeField] GameObject Building;
    [SerializeField] GameObject PlayerArmature;
    public Material _MeshMaterial;
    public Material _MeshMaterialBulding;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Phantom")
        {
            if (_MeshMaterial != null)
            {
                Material[] mats = PlayerArmature.GetComponent<SkinnedMeshRenderer>().materials;

                for (int i = 0; i < mats.Length; i++)
                {
                    mats[i] =  new Material(Shader.Find("Shader Graphs/Transparent"));  
                }
                PlayerArmature.GetComponent<SkinnedMeshRenderer>().materials = mats; 

            }

            Building.GetComponent<MeshCollider>().enabled = false;

            if (_MeshMaterialBulding != null)
            {
                Material[] mats = Building.GetComponent<MeshRenderer>().materials;
                for(int i = 0; i< mats.Length; i++)
                {
                    mats[i] = new Material(Shader.Find("Shader Graphs/VertexWave"));
                }
                Building.GetComponent< MeshRenderer>().materials = mats;

            }

        }
    }
}
