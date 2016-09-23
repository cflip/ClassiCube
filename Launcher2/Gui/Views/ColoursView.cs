﻿// ClassicalSharp copyright 2014-2016 UnknownShadow200 | Licensed under MIT
using System;
using System.Drawing;
using ClassicalSharp;
using Launcher.Gui.Widgets;
using OpenTK.Input;

namespace Launcher.Gui.Views {
	
	public sealed class ColoursView : IView {
		
		public ColoursView( LauncherWindow game ) : base( game ) {
			widgets = new LauncherWidget[25];
		}
		internal int defIndex;

		public override void DrawAll() {
			UpdateWidgets();
			RedrawAllButtonBackgrounds();
			
			using( drawer ) {
				drawer.SetBitmap( game.Framebuffer );
				RedrawAll();
			}
		}
		
		public override void Init() {
			titleFont = new Font( game.FontName, 15, FontStyle.Bold );
			inputFont = new Font( game.FontName, 14, FontStyle.Regular );
			inputHintFont = new Font( game.FontName, 12, FontStyle.Italic );
			UpdateWidgets();
		}
		
		void UpdateWidgets() {
			widgetIndex = 0;
			MakeAllRGBTriplets( false );
			Makers.Label( this, "Background", inputFont )
				.SetLocation( Anchor.Centre, Anchor.Centre, -60, -100 );
			Makers.Label( this, "Button border", inputFont )
				.SetLocation( Anchor.Centre, Anchor.Centre, -70, -60 );
			Makers.Label( this, "Button highlight", inputFont )
				.SetLocation( Anchor.Centre, Anchor.Centre, -80, -20 );
			Makers.Label( this, "Button", inputFont )
				.SetLocation( Anchor.Centre, Anchor.Centre, -40, 20 );
			Makers.Label( this, "Active button", inputFont )
				.SetLocation( Anchor.Centre, Anchor.Centre, -70, 60 );
			
			Makers.Label( this, "Red", titleFont )
				.SetLocation( Anchor.Centre, Anchor.Centre, 30, -130 );
			Makers.Label( this, "Green", titleFont )
				.SetLocation( Anchor.Centre, Anchor.Centre, 95, -130 );
			Makers.Label( this, "Blue", titleFont )
				.SetLocation( Anchor.Centre, Anchor.Centre, 160, -130 );
			
			defIndex = widgetIndex;
			Makers.Button( this, "Default colours", 160, 35, titleFont )
				.SetLocation( Anchor.Centre, Anchor.Centre, 0, 120 );
			Makers.Button( this, "Back", 80, 35, titleFont )
				.SetLocation( Anchor.Centre, Anchor.Centre, 0, 170 );
		}
		
		public void MakeAllRGBTriplets( bool force ) {
			widgetIndex = 0;
			MakeRGBTriplet( LauncherSkin.BackgroundCol, force, -100 );
			MakeRGBTriplet( LauncherSkin.ButtonBorderCol, force, -60 );
			MakeRGBTriplet( LauncherSkin.ButtonHighlightCol, force, -20 );
			MakeRGBTriplet( LauncherSkin.ButtonForeCol, force, 20 );
			MakeRGBTriplet( LauncherSkin.ButtonForeActiveCol, force, 60 );
		}
		
		void MakeRGBTriplet( FastColour defCol, bool force, int y ) {
			MakeInput( GetCol( defCol.R, force ), 55, false, 3, null )
				.SetLocation( Anchor.Centre, Anchor.Centre, 30, y );
			MakeInput( GetCol( defCol.G, force ), 55, false, 3, null )
				.SetLocation( Anchor.Centre, Anchor.Centre, 95, y );
			MakeInput( GetCol( defCol.B, force ), 55, false, 3, null )
				.SetLocation( Anchor.Centre, Anchor.Centre, 160, y );
		}
		
		string GetCol( byte col, bool force ) {
			if( force ) return col.ToString();
			LauncherWidget widget = widgets[widgetIndex];
			return widget == null ? col.ToString() : widget.Text;
		}
	}
}
