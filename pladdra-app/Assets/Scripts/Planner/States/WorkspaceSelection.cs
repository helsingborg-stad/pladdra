using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class WorkspaceSelection : IPlannerState
    {
        public PlannerController planner { get; set; }

        bool isMinScale
        {
            get
            {
                return planner.context.grid.scale == planner.context.grid.minScale;
            }
        }


        string scaleButtonText
        {
            get
            {
                if (isMinScale)
                {
                    return "Skala upp";
                }
                return "Skala ner";
            }
        }

        public void OnMount()
        {
            planner.context.grid.OnScaleChanged += SetScaleButtonText;
            planner.plannerGUI.editGridGUI.removeGridButton.onClick.AddListener(OnClickRemoveGrid);
            planner.plannerGUI.editGridGUI.lockGridButton.onClick.AddListener(OnClickLockGrid);
            planner.plannerGUI.editGridGUI.scaleGridButton.onClick.AddListener(OnClickScaleGrid);


            planner.context.grid.visible = true;
            planner.context.ar.planeDetection = true;
            planner.context.grid.isSelectable = true;


            planner.workspaceController.workspaceView.leanSelect.DeselectWithNothing = false;
            planner.workspaceController.workspaceView.leanSelect.DeselectAll();
            planner.workspaceController.workspaceView.leanSelect.Select(planner.workspaceController.workspaceView.leanSelectable);

            SetScaleButtonText();

            planner.plannerGUI.editGridGUI.Show();
        }

        private void SetScaleButtonText()
        {
            planner.plannerGUI.editGridGUI.scaleGridButtonText.text = scaleButtonText;
        }

        public void OnUnmount()
        {
            planner.context.grid.OnScaleChanged -= SetScaleButtonText;
            planner.plannerGUI.editGridGUI.removeGridButton.onClick.RemoveListener(OnClickRemoveGrid);
            planner.plannerGUI.editGridGUI.lockGridButton.onClick.RemoveListener(OnClickLockGrid);
            planner.plannerGUI.editGridGUI.scaleGridButton.onClick.RemoveListener(OnClickScaleGrid);

            planner.context.ar.planeDetection = false;
            planner.context.grid.isSelectable = false;

            planner.workspaceController.workspaceView.leanSelect.DeselectWithNothing = true;
            planner.workspaceController.workspaceView.leanSelect.DeselectAll();

            planner.plannerGUI.editGridGUI.Hide();
        }

        public void OnClickScaleGrid()
        {
            planner.context.grid.scale = isMinScale
            ? planner.context.grid.maxScale
            : planner.context.grid.minScale;
        }

        public void OnClickLockGrid()
        {
            planner.context.grid.isSelectable = true;
            planner.SetState(new Build());
        }

        public void OnClickRemoveGrid()
        {
            if (!isMinScale)
                planner.context.grid.scale = planner.context.grid.minScale;
            planner.SetState(new PlaneDetection());
        }
    }
}