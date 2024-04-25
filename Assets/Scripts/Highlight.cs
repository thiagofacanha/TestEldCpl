using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [SerializeField] private string highlightTAG = "Highlight";
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Camera rayCastCamera;
    private Transform _selection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            selectionRenderer = null;
        }

        var rayCast = new Ray(rayCastCamera.transform.position, rayCastCamera.transform.forward);
        Debug.DrawRay(rayCast.origin, rayCast.direction * 500f, Color.red);
        RaycastHit hitObject;
        if (Physics.Raycast(rayCast, out hitObject))
        {
            var selection = hitObject.transform;
            if (selection.CompareTag(highlightTAG))
            {


                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null && selection.GetComponent<ItemController>() != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    GameManager.instance.HighLightedObject = selection.gameObject;
                }
                _selection = selection;
            }
        }


    }
}
