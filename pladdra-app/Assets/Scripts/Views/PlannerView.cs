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

namespace Pladdra.MVC.Views
{
    public class PlannerView : View
    {
        private IPlannerModel context;
        private IPlannerController controller;
        private UnityEvent renderEvent;
        private bool shouldRender = true;

        public override void Initialize()
        {
            renderEvent = new UnityEvent();
            context = new PlannerModel();
            controller = new PlannerController(context, renderEvent);
            renderEvent.AddListener(() => shouldRender = true);
        }

        private void Update()
        {
            if (shouldRender)
            {
                shouldRender = false;

                //
            }
        }
    }
}
