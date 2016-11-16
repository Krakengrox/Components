using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class Detector : MonoBehaviour
{

    List<GameObject> enterObElementTag;
    AutomaticMovement automaticMovement = null;

    void Awake()
    {
        enterObElementTag = new List<GameObject>();
        this.automaticMovement = this.GetComponent<AutomaticMovement>();
    }

    void OnTriggerEnter(Collider ob)
    {
        if (ob.gameObject.tag == "Element")
        {
            Debug.Log(ob.gameObject.name);
            enterObElementTag.Add(ob.gameObject);
        }
    }

    void OnTriggerExit(Collider ob)
    {
        if (ob.gameObject.tag == "Element")
        {
            enterObElementTag.Remove(ob.gameObject);
        }
    }

    GameObject FollowElement()
    {
        GameObject followTarget;
        if (enterObElementTag.Count <= 0)
        {
            followTarget = null;
        }
        else
        {
            followTarget = this.enterObElementTag[0];
            float fDistance = (this.gameObject.transform.position - followTarget.transform.position).sqrMagnitude;
            for (int i = 0; i < this.enterObElementTag.Count; i++)
            {
                float nDisctance = (this.gameObject.transform.position - enterObElementTag[i].transform.position).sqrMagnitude;
                if (nDisctance < fDistance)
                {
                    followTarget = this.enterObElementTag[i];
                    fDistance = nDisctance;
                }
            }
        }

        return followTarget;
    }

    void Update()
    {
        this.automaticMovement.target = FollowElement();
    }

    public void RemoveOb(GameObject ob)
    {
        this.enterObElementTag.Remove(ob);
    }
}
