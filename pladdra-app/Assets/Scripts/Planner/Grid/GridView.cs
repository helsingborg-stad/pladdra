using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

using Pladdra.MVC.Models;
using Pladdra.MVC.Controllers;
using Pladdra.Components;
using UnityEngine.PlayerLoop;

namespace Pladdra.MVC.Views
{
    using Lean.Common;
    using Lean.Touch;

    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class GridView : View
    {
        public int xSize, ySize;
        private Vector3[] vertices;
        private Mesh mesh;
        private Material[] materials;
        private Material backgroundMaterial;
        private Material tileMaterial;
        public MeshRenderer meshRenderer;
        public MeshFilter filter;
        public BoxCollider boxCollider;

        bool isSelected;

        public override void Initialize()
        {
            boxCollider = GetComponent<BoxCollider>();
            filter = GetComponent<MeshFilter>();
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
                backgroundMaterial.SetColor("_Color", new Color(1f, 0f, 0f, 0.12f));
                backgroundMaterial.SetColor("_SolidOutline", new Color(1f, 0f, 0f, 0.66f));
            }
            else
            {
                backgroundMaterial.SetColor("_Color", new Color(1f, 1f, 1f, 0.16f));
                backgroundMaterial.SetColor("_SolidOutline", new Color(1f, 1f, 1f, 0.66f));
            }
        }

        void Update()
        {

        }
    }
}
