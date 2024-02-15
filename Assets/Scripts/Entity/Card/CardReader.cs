using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    // Start is called before the first frame update

    Sensor[] Sensors;
    GameObject Sensor;

    Vector3 InitPos;
    void Start()
    {
        Sensor = Resources.Load("Prefabs/Sensor1") as GameObject;
        InitPos = new Vector3(transform.position.x, transform.position.y - 100f, 0);
        Sensors = new Sensor[4];
        for (int i = 0; i < Sensors.Length; i++)
        {
            GameObject _nextSensor = Instantiate(Sensor, gameObject.transform);
            _nextSensor.transform.position = InitPos;
            Sensors[i] = _nextSensor.GetComponentInChildren<Sensor>();
            InitPos = new Vector3(InitPos.x, InitPos.y + 50f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RebootSensors()
    {
        foreach (Sensor sensor in Sensors)
        {
            sensor.Reload();
        }
    }

    public bool Verify()
    {
        foreach (Sensor sensor in Sensors)
        {
            if (!sensor.isRead) return false;
        }
        return true;
    }
}
