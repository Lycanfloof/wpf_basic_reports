﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_basic_reports.Model
{
    internal class TownDisplay
    {
        public IList<Town> Towns { get; set; }
        public TownDisplay()
        {
            Towns = new List<Town>();
        }
        public void ReadData(string path)
        {
            using StreamReader sr = File.OpenText(path);
            string? value;
            sr.ReadLine();
            while ((value = sr.ReadLine()) != null)
            {
                string[] values = value.Split();
                Towns.Add(new Town(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), values[2], values[3]));
            }
        }
    }
}