using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace CellularAutomata
{
	static class Input
	{
		private static KeyboardState keyboardState, lastKeyboardState;
		private static MouseState mouseState, lastMouseState;
		private static GamePadState gamepadState, lastGamepadState;

		public static void Update()
		{
			lastKeyboardState = keyboardState;
			lastMouseState = mouseState;
			lastGamepadState = gamepadState;

			keyboardState = Keyboard.GetState();
			mouseState = Mouse.GetState();
			gamepadState = GamePad.GetState(PlayerIndex.One);
		}

		public static bool KeyPressed(Keys key)
		{
			return (!lastKeyboardState.IsKeyDown(key) && keyboardState.IsKeyDown(key));
		}

		public static bool KeyDown(Keys key)
        {
			return keyboardState.IsKeyDown(key);
		}

		public static bool KeyUp(Keys key)
		{
			return keyboardState.IsKeyUp(key);
		}

		public static bool MouseLeftPressed()
		{
			return (!(lastMouseState.LeftButton == ButtonState.Pressed) && (mouseState.LeftButton == ButtonState.Pressed));
		}

		public static bool MouseLeftDown()
		{
			return (mouseState.LeftButton == ButtonState.Pressed);
		}

		public static bool MouseRightPressed()
		{
			return (!(lastMouseState.RightButton == ButtonState.Pressed) && (mouseState.RightButton == ButtonState.Pressed));
		}

		public static bool MouseRightDown()
		{
			return (mouseState.RightButton == ButtonState.Pressed);
		}

		public static bool MouseMiddlePressed()
		{
			return (!(lastMouseState.MiddleButton == ButtonState.Pressed) && (mouseState.MiddleButton == ButtonState.Pressed));
		}

		public static bool MouseMiddleDown()
		{
			return (mouseState.MiddleButton == ButtonState.Pressed);
		}

		public static bool MouseWheelUp()
		{
			return (mouseState.ScrollWheelValue > lastMouseState.ScrollWheelValue);
		}

		public static bool MouseWheelDown()
		{
			return (mouseState.ScrollWheelValue < lastMouseState.ScrollWheelValue);
		}

		public static Point MouseCoordinates()
        {
			return mouseState.Position;
        }

		public static bool ButtonPressed(Buttons button)
		{
			return (!lastGamepadState.IsButtonDown(button) && gamepadState.IsButtonDown(button));
		}
	}
}