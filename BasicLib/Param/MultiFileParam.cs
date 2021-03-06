﻿using System;
using System.Windows.Forms;
using BasicLib.Forms.Select;
using BasicLib.Util;

namespace BasicLib.Param{
	[Serializable]
	public class MultiFileParam : Parameter{
		public string Filter { get; set; }
		public string[] Value { get; set; }
		public string[] Default { get; private set; }
		public MultiFileParam(string name) : this(name, new string[0]) {}

		public MultiFileParam(string name, string[] value) : base(name){
			Value = value;
			Default = value;
			Filter = null;
		}

		public string[] Value2{
			get{
				SetValueFromControl();
				return Value;
			}
		}
		public override string StringValue{
			get { return StringUtils.Concat(",", Value); }
			set{
				if (value.Trim().Length == 0){
					Value = new string[0];
					return;
				}
				Value = value.Split(',');
			}
		}

		public override void ResetValue(){
			Value = Default;
		}

		public override void ResetDefault(){
			Default = Value;
		}

		public override bool IsModified { get { return !ArrayUtils.EqualArrays(Value, Default); } }

		public override void SetValueFromControl(){
			MultiFileParameterPanel tb = (MultiFileParameterPanel) control;
			string[] val = tb.Filenames;
			Value = val;
		}

		public override void Clear(){
			Value = new string[0];
		}

		public override void UpdateControlFromValue(){
			if (control == null) {
				return;
			}
			MultiFileParameterPanel lfp = (MultiFileParameterPanel)control;
			lfp.Filenames = Value;
		}

		protected override Control Control { get { return new MultiFileParameterPanel{Filter = Filter, Filenames = Value}; } }

		public override object Clone(){
			return new MultiFileParam(Name, Value){Help = Help, Visible = Visible, Filter = Filter, Default = Default};
		}

		public override float Height { get { return 120; } }
	}
}