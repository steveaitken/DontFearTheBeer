﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontFearTheBeer.Model
{
    public class Review
    {
        public int BeerId { get; set; }

        public Beer Beer { get; set; }

        public int TasterId { get; set; }

        public Taster Taster { get; set; }

        /// <summary>Get and set the person's rating of the session from 1-5 (0=not rated).</summary>
        [Range(0, 5)]
        public int Rating { get; set; }

        public bool WouldRecommend { get; set; }

        public string Notes { get; set; }

        public DateTime Date { get; set; }

    }
}