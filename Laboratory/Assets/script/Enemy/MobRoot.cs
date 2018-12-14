using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobRoot : MonoBehaviour {

    public static MobRoot Instance;

    //爆発
    public GameObject Bom;

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }
}
