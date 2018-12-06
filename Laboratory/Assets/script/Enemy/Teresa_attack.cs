using UnityEngine;
using System.Collections;
public class Teresa_attack : MonoBehaviour
{
    public GameObject[] Train;
    public float loopTime = 1.0f;
    int lastNumber = -1;




    void Start()
    {
        // number = Random.Range(0, Train.Length);
        // Instantiate(Train[number], transform.position, transform.rotation);

        StartCoroutine("shot");
    }

   
    private IEnumerator shot(){




        int number;
        while(true){
            yield return new WaitForSeconds(loopTime);

            number = Random.Range(0, Train.Length);
            if ( lastNumber != -1 ){
                Train[lastNumber].GetComponent<UbhShotCtrl>().StopShotRoutine();    
            }
 
            Train[number].GetComponent<UbhShotCtrl>().StartShotRoutine(0.4f);
 
            lastNumber = number;
        }
    }
}



// 0はじまり
// nantoka[5]
// 0, 1, 2, 3,4 
// http://ftvoid.com/blog/post/1017
