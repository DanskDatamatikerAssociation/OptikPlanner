﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OptikPlanner.Model
{
    public class CheckComboBox : ComboBox
    {
        public CheckComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;

        }

        void CheckComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }

            if (!(Items[e.Index] is CheckComboBoxItem))
            {
                e.Graphics.DrawString(
                    Items[e.Index].ToString(),
                    this.Font,
                    Brushes.Black,
                    new Point(e.Bounds.X, e.Bounds.Y));
                return;
            }

            CheckComboBoxItem box = (CheckComboBoxItem)Items[e.Index];

            CheckBoxRenderer.RenderMatchingApplicationState = true;
            CheckBoxRenderer.DrawCheckBox(
                e.Graphics,
                new Point(e.Bounds.X, e.Bounds.Y),
                e.Bounds,
                box.Text,
                this.Font,
                (e.State & DrawItemState.Focus) == 0,
                box.CheckState ? CheckBoxState.CheckedNormal :
                    CheckBoxState.UncheckedNormal);
        }

    }
}
