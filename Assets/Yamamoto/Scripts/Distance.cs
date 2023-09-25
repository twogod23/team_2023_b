using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
   
 
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject player;
   
  Vector3 pos;
  private bool STOP;
    
   
    void Start()
    {
         pos = this.transform.position;
    }

     void OnCollisionEnter(Collision collision)
{
  if (collision.gameObject.CompareTag("Player"))
  {
    STOP = true;
     var rigidbody = GetComponent<Rigidbody>();
rigidbody.AddForce(-transform.right * 10f, ForceMode.VelocityChange);
    
    Invoke("STOPoff", 1f);
  }
}
    void FixedUpdate()
    {
        /* ターゲットのポジションを取得 */
        Vector3 targetPos = target.transform.position;
 
        /* プレイヤーのポジションを取得 */
        Vector3 playerPos = player.transform.position;
 
        /* ターゲットとプレイヤーの距離を取得 */
       float dist = targetPos.magnitude;
       float disp = playerPos.magnitude;
       float dis = dist - disp;

       
 
        if (STOP == false ){
        if(dis > -20)
        {
        if(dis < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            pos.x -= 0.05f;
            
        }
        }
        if(dis < 10)
        {
        if(dis > 0)
        {
             transform.rotation = Quaternion.Euler(0, 0, 0);
            pos.x += 0.05f;
            
        }
      
        }
        this.transform.position = pos;
        }
        
    }
    void STOPoff()
    {
    pos.x = this.transform.position.x;
    STOP = false;
    }
}
