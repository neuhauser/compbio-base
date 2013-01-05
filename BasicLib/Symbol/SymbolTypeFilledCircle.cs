using System;
using System.Collections.Generic;
using System.Drawing;
using BasicLib.Graphic;

namespace BasicLib.Symbol{
	public class SymbolTypeFilledCircle : SymbolType{
		public SymbolTypeFilledCircle(int index) : base(index) {}
		public override string Name { get { return "Filled circle"; } }

		public override void GetPath(int size, out int[] pathX, out int[] pathY){
			int s2 = size/2;
			List<int> x = new List<int>();
			List<int> y = new List<int>();
			for (int i = -s2; i <= s2; i++){
				int j = (int) Math.Round(Math.Sqrt(s2*s2 - i*i));
				for (int k = -j; k <= j; k++){
					x.Add(i);
					y.Add(k);
					x.Add(k);
					y.Add(i);
				}
			}
			pathX = x.ToArray();
			pathY = y.ToArray();
		}

		public override void Draw(int size, int x, int y, IGraphics g, Pen pen, Brush brush){
			int s2 = size/2;
			g.FillEllipse(brush, x - s2, y - s2, size, size);
			if (pen != null){
				g.DrawEllipse(pen, x - s2, y - s2, size, size);
			}
		}
	}
}