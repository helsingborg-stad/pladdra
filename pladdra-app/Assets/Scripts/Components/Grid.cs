using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pladdra.Components
{

    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Grid : MonoBehaviour
    {
        public int xSize, ySize;
        private Vector3[] vertices;
        private Mesh mesh;
        Material[] materials;
        Material backgroundMaterial;
        Material tileMaterial;
        MeshRenderer meshRenderer;

        bool isSelected;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            materials = meshRenderer.materials;

            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i].shader.name == "Sprites/Outline")
                    backgroundMaterial = materials[i];

                if (materials[i].shader.name != "Sprites/Outline")
                    tileMaterial = materials[i];
            }
        }

        public void SetSelected(bool selected)
        {
            if (isSelected == selected)
                return;

            isSelected = selected;

            if (isSelected == true)
            {
                backgroundMaterial.SetColor("_Color", new Color(1f, 0f, 0f, 0.56f));
                backgroundMaterial.SetColor("_SolidOutline", new Color(1f, 0f, 0f, 0.66f));
            }
            else
            {
                backgroundMaterial.SetColor("_Color", new Color(1f, 1f, 1f, 0.56f));
                backgroundMaterial.SetColor("_SolidOutline", new Color(1f, 1f, 1f, 0.66f));
            }
        }

        void Update()
        {

        }
    }

}