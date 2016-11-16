using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutomaticMovement : MonoBehaviour
{

    public bool followTarget;

    public int speed = 3;

    public GameObject target;


    void LateUpdate()
    {
        if (target != null)
        {
            this.transform.position += Time.deltaTime * this.speed * this.transform.forward.normalized;

            if (followTarget)
            {
                this.transform.LookAt(target.transform.position);
            }
            if ((this.transform.position - target.transform.position).sqrMagnitude < 0.5)
            {
                this.GetComponent<Detector>().RemoveOb(target);
                GameObject.Destroy(target);
                target = null;
            }
        }
    }
}
