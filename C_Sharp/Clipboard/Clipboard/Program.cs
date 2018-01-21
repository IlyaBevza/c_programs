﻿
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace mClipboard
{
	class Program
	{
        [STAThread]
		public static void Main(string[] args)
		{
            if (!Clipboard.ContainsText())
            {
                Console.WriteLine("No text in clipboard.");
                Console.ReadKey();
            }
            else
            {
                string clip = Clipboard.GetText();
                List<char> into = new List<char>();
                into.Add('\"');
                foreach(char ch in clip)
                {
                    if (ch == '\"') into.Add('\"');
                    if (ch == '\n')
                    {
                        into.Add(ch);
                        into.Add('|');
                        continue;
                    }
                    into.Add(ch);
                }
                into.Add(';');
                Clipboard.SetText(new string(into.ToArray()));
            }
		}
	}
}