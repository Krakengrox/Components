using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpanwElements : MonoBehaviour
{
    Vector3 cubeSize;
    public Button spawnElement;
    public string type = " ";
    void Start()
    {
        spawnElement.onClick.AddListener(Generate);
    }

    public void Generate()
    {
        cubeSize = (this.gameObject.GetComponent<Collider>().bounds.size * 0.5f);
        GameObject element = GameObject.Instantiate(Resources.Load(type)) as GameObject;
        element.transform.position = new Vector3
            (Random.Range(this.transform.position.x - cubeSize.x, cubeSize.x + this.transform.position.x),
            Random.Range(this.transform.position.y - cubeSize.y, cubeSize.y + this.transform.position.y),
            Random.Range(this.transform.position.z - cubeSize.z, cubeSize.z + this.transform.position.z));
    }
}