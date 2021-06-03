using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyboardHook
{
    public class KeyboardHook
    {
        /* 
         * Following class comes from LiveSplit released under MIT licence:
         * The MIT License (MIT)
         * Copyright (c) 2013-2020 Christopher Serr and Sergey Papushin
         * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
         * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
         * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
        */
        protected Dictionary<Keys, bool> RegisteredKeys { get; set; }
        public event KeyEventHandler KeyPressed;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetAsyncKeyState(Keys vkey);

        public KeyboardHook()
        {
            RegisteredKeys = new Dictionary<Keys, bool>();
        }

        public void RegisterHotKey(Keys key)
        {
            if (!RegisteredKeys.ContainsKey(key))
                RegisteredKeys.Add(key, false);
        }

        public void UnregisterAllHotkeys()
        {
            RegisteredKeys.Clear();
        }

        public void Poll()
        {
            foreach (var keyPair in RegisteredKeys.ToList())
            {
                var key = keyPair.Key;
                var modifiersDown = true;
                var modifiers = Keys.None;
                if (key.HasFlag(Keys.Shift))
                {
                    modifiersDown &= IsKeyDown(Keys.ShiftKey);
                    modifiers |= Keys.Shift;
                }
                if (key.HasFlag(Keys.Control))
                {
                    modifiersDown &= IsKeyDown(Keys.ControlKey);
                    modifiers |= Keys.Control;
                }
                if (key.HasFlag(Keys.Alt))
                {
                    modifiersDown &= IsKeyDown(Keys.Menu);
                    modifiers |= Keys.Alt;
                }

                var keyWithoutModifiers = key & ~modifiers;
                var result = GetAsyncKeyState(keyWithoutModifiers);
                var isPressed = ((result >> 15) & 1) == 1;
                var wasPressedBefore = keyPair.Value;
                RegisteredKeys[key] = isPressed;

                if (modifiersDown && isPressed && !wasPressedBefore)
                    KeyPressed?.Invoke(this, new KeyEventArgs(key));
            }
        }

        protected bool IsKeyDown(Keys key)
        {
            var result = GetAsyncKeyState(key);
            return ((result >> 15) & 1) == 1;
        }
    }
}
