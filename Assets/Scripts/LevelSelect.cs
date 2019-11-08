using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelSelect : MonoBehaviour
{
    public List<Levels> levels = new List<Levels>();

    [Space]
    [Header("Public References")]
    public Camera levelSelectCamera;
    public GameObject LevelPoint;
    public GameObject LevelButton;
    public Transform modelTransform;
    public Transform LevelButtonContainer;

    [Space]
    public Vector2 visualOffset; // for adjusting camera position

    void Start()
    {
        foreach (Levels L in levels)
        {
            SpawnLevelPoint(L);
        }

        if (levels.Count > 0)
        {
            LookAtLevel(levels[0]);
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(LevelButtonContainer.GetChild(0).gameObject);
        }
    }

    private void SpawnLevelPoint(Levels L)
    {
        GameObject level = Instantiate(LevelPoint, modelTransform);
        level.transform.localEulerAngles = new Vector3(L.y + visualOffset.y, -L.x - visualOffset.x, 0);
        L.visualPoint = level.transform.GetChild(0);

        SpawnLevelButton(L);
    }

    private void SpawnLevelButton(Levels L)
    {
        Levels level = L;
        Button levelButton = Instantiate(LevelButton,LevelButtonContainer).GetComponent<Button>();
        levelButton.onClick.AddListener(() => LookAtLevel(level));

        levelButton.transform.GetChild(0).GetComponentInChildren<Text>().text = L.name;
    }

    public void LookAtLevel(Levels L)
    {
        Transform cameraParent = levelSelectCamera.transform.parent;
        Vector3 rot = new Vector3(L.y, -L.x, 0);
        cameraParent.DORotate(rot, 0.5f, RotateMode.Fast);
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.red;

        // only draws when there are levels
        if (levels.Count > 0)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                // create two empty game objects for levels
                GameObject point = new GameObject();
                GameObject parent = new GameObject();

                point.transform.position += new Vector3(0, 0, -0.5f); // move the point to the edge of the sphere when the sphere is at 0,0,0
                point.transform.parent = parent.transform;
                parent.transform.eulerAngles = new Vector3(visualOffset.y, -visualOffset.x, 0);

                if (!Application.isPlaying)
                {
                    Gizmos.DrawWireSphere(point.transform.position, 0);
                }

                //spint the parent object based on the stage coordinates
                parent.transform.eulerAngles += new Vector3(levels[i].y, -levels[i].x, 0);
                //draw a gizmo sphere // handle label in the point object's position
                Gizmos.DrawSphere(point.transform.position, 0.05f);
                //destroy all
                DestroyImmediate(point);
                DestroyImmediate(parent);
            }
        }
#endif
    }
}

[System.Serializable]
public class Levels
{
    public string name;
    [Range(-180,180)]
    public float x,y;

    [HideInInspector]
    public Transform visualPoint;
}
