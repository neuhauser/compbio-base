﻿using System.Drawing;
using BasicLib.Forms.Base;
using BasicLib.Graphic;

namespace BasicLib.Forms.Scroll{
	internal class ScrollComponentView : BasicView{
		protected readonly CompoundScrollableControl main;

		protected ScrollComponentView(CompoundScrollableControl main){
			this.main = main;
		}

		protected internal override sealed void OnPaintBackground(IGraphics g, int width, int height) {
			if (main == null){
				return;
			}
			if (main.BackColor.IsEmpty || main.BackColor == Color.Transparent){
				return;
			}
			Brush b = new SolidBrush(main.BackColor);
			g.FillRectangle(b, 0, 0, width, height);
		}
	}
}