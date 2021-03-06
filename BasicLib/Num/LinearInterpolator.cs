using System;
using System.IO;

namespace BasicLib.Num{
	public class LinearInterpolator{
		private double[] xvals;
		private double[] yvals;

		public LinearInterpolator(double[] xvals, double[] yvals){
			this.xvals = xvals;
			this.yvals = yvals;
		}

		public LinearInterpolator(double val){
			xvals = new[]{0.0, 1.0};
			yvals = new[]{val, val};
		}

		public LinearInterpolator(BinaryReader reader){
			int len = reader.ReadInt32();
			xvals = new double[len];
			yvals = new double[len];
			for (int i = 0; i < len; i++){
				xvals[i] = reader.ReadDouble();
				yvals[i] = reader.ReadDouble();
			}
		}

		public void Write(BinaryWriter writer){
			writer.Write(xvals.Length);
			for (int i = 0; i < xvals.Length; i++){
				writer.Write(xvals[i]);
				writer.Write(yvals[i]);
			}
		}

		public double Get(double x){
			return Get(x, xvals, yvals);
		}

		public static double Get(double x, double[] xvals, double[] yvals){
			if (xvals.Length == 0){
				return double.NaN;
			}
			if (xvals.Length == 1){
				return yvals[0];
			}
			if (x <= xvals[0]){
				return Interpolate(xvals[0], xvals[1], yvals[0], yvals[1], x);
			}
			if (x >= xvals[xvals.Length - 1]){
				return Interpolate(xvals[xvals.Length - 2], xvals[xvals.Length - 1], yvals[xvals.Length - 2],
					yvals[xvals.Length - 1], x);
			}
			int a = Array.BinarySearch(xvals, x);
			return a >= 0 ? yvals[a] : Interpolate(xvals[-2 - a], xvals[-1 - a], yvals[-2 - a], yvals[-1 - a], x);
		}

		public double Get(double x, out double[] dyda){
			return Get(x, out dyda, xvals, yvals);
		}

		public static double Get(double x, out double[] dyda, double[] xvals, double[] yvals){
			dyda = new double[xvals.Length];
			if (xvals.Length == 0){
				return double.NaN;
			}
			if (xvals.Length == 1){
				dyda[0] = 1;
				return yvals[0];
			}
			if (x <= xvals[0]){
				dyda[0] = Dy1(xvals[0], xvals[1], x);
				dyda[1] = Dy2(xvals[0], xvals[1], x);
				return Interpolate(xvals[0], xvals[1], yvals[0], yvals[1], x);
			}
			if (x >= xvals[xvals.Length - 1]){
				dyda[xvals.Length - 2] = Dy1(xvals[xvals.Length - 2], xvals[xvals.Length - 1], x);
				dyda[xvals.Length - 1] = Dy2(xvals[xvals.Length - 2], xvals[xvals.Length - 1], x);
				return Interpolate(xvals[xvals.Length - 2], xvals[xvals.Length - 1], yvals[xvals.Length - 2],
					yvals[xvals.Length - 1], x);
			}
			int a = Array.BinarySearch(xvals, x);
			if (a >= 0){
				dyda[a] = 1;
				return yvals[a];
			}
			dyda[-2 - a] = Dy1(xvals[-2 - a], xvals[-1 - a], x);
			dyda[-1 - a] = Dy2(xvals[-2 - a], xvals[-1 - a], x);
			return Interpolate(xvals[-2 - a], xvals[-1 - a], yvals[-2 - a], yvals[-1 - a], x);
		}

		private static double Dy2(double x1, double x2, double x){
			return (x - x1)/(x2 - x1);
		}

		private static double Dy1(double x1, double x2, double x){
			return (x2 - x)/(x2 - x1);
		}

		private static double Interpolate(double x1, double x2, double y1, double y2, double x){
			return (y2 - y1)/(x2 - x1)*(x - x1) + y1;
		}

		public void Dispose(){
			xvals = null;
			yvals = null;
		}

		public void FlattenEnds(){
			if (xvals.Length == 1){
				xvals = new[]{0.0, 1.0};
				yvals = new[]{yvals[0], yvals[0]};
				return;
			}
			double[] newx = new double[xvals.Length + 2];
			double[] newy = new double[xvals.Length + 2];
			newx[0] = 2*xvals[0] - xvals[1];
			newy[0] = yvals[0];
			for (int i = 0; i < xvals.Length; i++){
				newx[i + 1] = xvals[i];
				newy[i + 1] = yvals[i];
			}
			newx[xvals.Length + 1] = 2*xvals[xvals.Length - 1] - xvals[xvals.Length - 2];
			newy[xvals.Length + 1] = yvals[xvals.Length - 1];
			xvals = newx;
			yvals = newy;
		}

		public void Write(string filename){
			StreamWriter writer = new StreamWriter(filename);
			writer.WriteLine("x" + "\t" + "y");
			for (int i = 0; i < xvals.Length; i++){
				writer.WriteLine(xvals[i] + "\t" + yvals[i]);
			}
			writer.Close();
		}
	}
}