using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class Zen : IPlannerState
    {
        public TMP_Text zenButtonText;

        public PlannerController planner { get; set; }

        public void OnMount()
        {
            planner.context.grid.transperent = true;
            planner.context.showZenButton = true;
            planner.plannerGUI.menuButton.gameObject.SetActive(false);

            if (zenButtonText == null)
                zenButtonText = planner.plannerGUI.zenButton.gameObject.GetComponentInChildren<TMP_Text>();

            if (zenButtonText != null)
                zenButtonText.text = "Stäng av Zen";

        }

        public void OnUnmount()
        {
            planner.context.grid.transperent = false;
            planner.plannerGUI.menuButton.gameObject.SetActive(true);
            planner.context.showZenButton = false;
            if (zenButtonText != null)
                zenButtonText.text = "Zen";

        }
    }
}