using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerSight : MonoBehaviour
{
    // Start is called before the first frame update
    public float range = 100f;
    public Vector2 visionOffset;
    [Min(0)] public int maxBounces = 10;
    public Vec4Variable aim;
    public BoolVariable eyesClosed;
    public GameEvent deathEvent;
    public GameObject laserHitEffect;
    private List<LineRenderer> lines = new List<LineRenderer>();
    private int nextLine;
    [SerializeField]
    private LineRenderer lineTemplate;

    void Start()
    {

    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPosition = (Vector2)transform.position + visionOffset;
        aim.Value = mousePosition - myPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hideReflectedLine();
        sightCheck((Vector2)transform.position + visionOffset, aim.Value);
        //seeable afterwords
        this.gameObject.layer = 3;
    }
    void sightCheck(Vector2 origin, Vector2 angle)
    {
        int itr = 0;
        //prevents hitting self with initial gaze
        this.gameObject.layer = 2;
        Color color = Color.white;
        while (itr <= maxBounces)
        {
            //cast the ray
            RaycastHit2D hit = Physics2D.Raycast(origin, angle, range);
            if (hit)
            {
                drawReflectedLine(origin, hit.point, color, itr);
            }
            else
            {
                drawReflectedLine(origin, origin + angle * range, color, itr);
                // Debug.Log("No Hit: " + angle*range);
            }
            Debug.DrawRay(origin, angle * range, Color.red);

            if (hit.collider != null)
            {
                //not the best self-check...

                if (hit.collider.gameObject.TryGetComponent(out PlayerSight sight))
                {
                    Debug.Log("OWW");
                    deathEvent.Invoke();
                    //die
                }

                if(hit.collider.gameObject.TryGetComponent(out enemyDeath death)){
                    Debug.Log("vanquish");
                    death.dying = true;
                }

                if (hit.collider.gameObject.TryGetComponent(out Seeable seeable))
                {
                    seeable.whenSeen.Invoke(color);
                }

                if (hit.collider.gameObject.TryGetComponent(out Mirror mirror))
                {
                    if (mirror.isActiveAndEnabled)
                    {
                        //reflect light. Color stuff will probably go here too
                        origin = hit.point + hit.normal * 0.01f;
                        angle = Vector2.Reflect(angle, hit.normal);
                        color = mirror.ReflectColor(color);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
            itr++;
            //now you can self-hit
            this.gameObject.layer = 3;
        }
    }
    public void hideReflectedLine()
    {
        foreach (LineRenderer l in lines)
        {
            l.enabled = false;

            Light2D[] lights = l.GetComponentsInChildren<Light2D>();
            foreach (Light2D l2 in lights)
                l2.enabled = false;
        }
        nextLine = 0;
    }
    public void drawReflectedLine(Vector2 start, Vector2 end, Color c, int itr)
    {
        GameObject child;
        LineRenderer line;
        if (nextLine >= lines.Count)
        {
            child = Instantiate(lineTemplate.gameObject, transform);
            line = child.GetComponent<LineRenderer>();
            lines.Add(line);
        }
        else
        {
            line = lines[nextLine];
        }
        nextLine++;
        //child.transform.parent = transform;
        // Destroy(Instantiate(laserHitEffect, end, Quaternion.identity), 0.1f);


        //line.startWidth = 0.1f;
        //line.endWidth = 0.1f;
        //line.material = new Material(Shader.Find("Sprites/Default"));
        //print("color: " + c);
        line.enabled = true;
        line.startColor = c;
        line.endColor = c;
        line.numCapVertices = 20;
        Vector3 st = new Vector3(start.x, start.y, itr * 0.01f);
        Vector3 ed = new Vector3(end.x, end.y, itr * 0.01f);
        Light2D[] lights = line.GetComponentsInChildren<Light2D>();
        if (lights.Length > 1)
        {
            Light2D l1 = lights[0];
            Light2D l2 = lights[1];
            l1.color = c;
            l1.transform.position = st;
            l2.color = c;
            l2.transform.position = ed;
            // l1.enabled = true;
            l2.enabled = true;
        }
        line.SetPositions(new Vector3[] { st, ed });
        //Destroy(child, 10);
    }
}

