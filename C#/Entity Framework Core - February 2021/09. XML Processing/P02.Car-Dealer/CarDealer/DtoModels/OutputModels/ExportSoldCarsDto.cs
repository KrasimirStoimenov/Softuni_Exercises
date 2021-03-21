﻿using System.Xml.Serialization;

namespace CarDealer.DtoModels.OutputModels
{
    [XmlType("car")]
    public class ExportSoldCarsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}