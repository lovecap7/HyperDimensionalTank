using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBlock : MonoBehaviour
{
    public GameObject Object;
    float time;
    Vector3 vector;

    GameObject Temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time > 5)
        {
            Generate();

            //ŠÔ‚ÌÄŒv‘ª
            time = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Generate()
    {
        Temp = Instantiate(Object, new Vector3(3, Random.Range(3, 5), 0), Quaternion.identity);
    }
}
