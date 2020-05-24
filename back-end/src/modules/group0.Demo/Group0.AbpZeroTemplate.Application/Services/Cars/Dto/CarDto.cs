﻿
using System;

namespace Group0.AbpZeroTemplate.Application.Share.Cars.Dto
{
    /// <summary>
    /// <model cref="Car"></model>
    /// </summary>
    public class CarDto
    {
        public int? Id { get; set; }
        public string CarID { get; set; }
        public string CarCode { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string RecordStatus { get; set; }
        public string MakerId { get; set; }
        public DateTime? CreateDt { get; set; }
        public string AuthStatus { get; set; }
        public string CheckerId { get; set; }
        public DateTime? ApproveDt { get; set; }

    }
}
