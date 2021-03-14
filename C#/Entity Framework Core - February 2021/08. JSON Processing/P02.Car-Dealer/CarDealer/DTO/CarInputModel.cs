﻿using System.Collections.Generic;
using CarDealer.Models;

namespace CarDealer.DTO
{
    public class CarInputModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public int[] PartsId { get; set; }
    }
}
