//
// ScrollbarSample.cs
//
// Author:
//       Lluis Sanchez <lluis@xamarin.com>
//
// Copyright (c) 2013 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Xwt;

namespace Samples
{
	public class ScrollbarSample: Xwt.Table
	{
		Canvas canvas;
		Label label;
		Scrollbar vscroll;
		Scrollbar hscroll;

		public ScrollbarSample ()
		{
			NaturalWidth = 300;
			NaturalHeight = 300;

			canvas = new Canvas ();
			label = new Label ("Use the scrollbars\nto move this label");
			canvas.AddChild (label);

			Attach (canvas, 0, 0, AttachOptions.Expand|AttachOptions.Fill, AttachOptions.Expand|AttachOptions.Fill);

			vscroll = new VScrollbar () {
				LowerValue = 0,
				UpperValue = 300,
				PageIncrement = 10,
				PageSize = 50,
				StepIncrement = 1
			};
			Attach (vscroll, 1, 0, AttachOptions.Fill, AttachOptions.Expand|AttachOptions.Fill);
			
			hscroll = new HScrollbar () {
				LowerValue = 0,
				UpperValue = 300,
				PageIncrement = 10,
				PageSize = 50,
				StepIncrement = 1
			};
			Attach (hscroll, 0, 1, AttachOptions.Expand|AttachOptions.Fill, AttachOptions.Fill);

			vscroll.ValueChanged += HandleValueChanged;
			hscroll.ValueChanged += HandleValueChanged;
		}

		void HandleValueChanged (object sender, EventArgs e)
		{
			double w, h;
			w = label.Surface.GetPreferredWidth ().NaturalSize;
			h = label.Surface.GetPreferredHeightForWidth (w).NaturalSize;
			canvas.SetChildBounds (label, new Rectangle (hscroll.Value, vscroll.Value, w, h));
		}
	}
}

