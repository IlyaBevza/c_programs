﻿
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Query1C_To_Text
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
                List<char> temp=new List<char>();
                char ch;
                int num=0;
                for (int iy=0;iy<clip.Length;iy++){
                	ch=clip[iy];
                	if (iy==0 && ch=='\"') continue;
                	if(ch=='|') continue;
                	if(ch!='\"')num=0;
                	else num++;
                	if (num>1) continue;            
                	temp.Add(ch);
                }
                string result=new string(temp.ToArray());
                result=Regex.Replace(result,@"^[\s,]+|[\s,]+$", "");
                result=Regex.Replace(result,";$","");
                result=Regex.Replace(result,"\"$","");
                
 
              	
              Clipboard.SetText(result);
            }
		}
	}
}