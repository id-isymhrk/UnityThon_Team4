using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ItemController : MonoBehaviour, ISelectable, IGrabbable
{
    private Material[] _materials;
    public Material outlineMaterial;
    private bool isOutlineEnabled = false;
    private bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        _materials = GetComponent<Renderer>().materials;
        Array.Resize(ref _materials, _materials.Length + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSelected && isOutlineEnabled){
            deleteOutlineMatrial();
        }
        isSelected = false;
    }

    private void OnDestroy()
    {
        
    }

    public void Selected()
    {
        isSelected = true;
        if(!isOutlineEnabled){
            addOutlineMatrial();
        }
    }

    public void Grabble()
    {
        Destroy(this.gameObject);
    }
    
    private void addOutlineMatrial()
    {
        _materials[_materials.Length - 1] = outlineMaterial;
        isOutlineEnabled = true;
        this.GetComponent<Renderer>().materials = _materials;
    }
    private void deleteOutlineMatrial()
    {
        _materials[_materials.Length - 1] = null;
        this.GetComponent<Renderer>().materials = _materials;
        isOutlineEnabled = false;
    }
}
