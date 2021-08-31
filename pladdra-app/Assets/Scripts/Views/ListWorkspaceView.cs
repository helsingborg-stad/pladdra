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

using Newtonsoft.Json;
namespace Pladdra.MVC.Views
{
    [RequireComponent(typeof(WithReRender))]
    public class ListWorkspaceView : View
    {
        private IListWorkspaceModel context;
        private IListWorkspaceController controller;
        public UnityEvent render;
        private WithReRender withReRender;
        public GameObject itemPrefab;
        public VerticalLayoutGroup workspaceList;
        public Button backButton;
        private List<GameObject> items;
        private List<Pladdra.API.Types.Workspace> itemsToRender;
        private WorkspaceModel workspaceModel;

        public override void Initialize()
        {
            withReRender = GetComponent<WithReRender>();
            withReRender.OnRender += RenderItems;
            render = withReRender.renderEvent;
            context = new ListWorkspaceModel();
            controller = new ListWorkspaceController(context, render);

            backButton.onClick.AddListener(controller.OnClickBack);

            App.GetModel<WorkspaceModel>(out var workspaceModelInstance);
            workspaceModel = workspaceModelInstance;
        }

        private void InstantiateItem(Pladdra.API.Types.Workspace workspace)
        {
            GameObject newObj = (GameObject)Instantiate(itemPrefab, workspaceList.gameObject.transform);
            WorkspaceItem item = newObj.GetComponent<WorkspaceItem>();
            item.titleText.text = workspace.name;
            item.updatedDateText.text = workspace.updatedAt;
            item.loadButton.onClick.AddListener(() => controller.OnClickLoad(workspace.id));
            item.deleteButton.onClick.AddListener(() => controller.OnClickDelete(workspace.id));
            items.Add(newObj);
        }

        private void RenderItems()
        {
            if (items != null && items.Count > 0)
            {
                items.ForEach(obj =>
                {
                    Destroy(obj);
                });
            }

            items = new List<GameObject>();
            itemsToRender = workspaceModel.List();

            if (itemsToRender.Count > 0)
            {
                itemsToRender.ForEach(InstantiateItem);
            }
        }

        private void OnEnable()
        {
            if (workspaceModel != null)
            {
                RenderItems();
            }
        }
    }
}
