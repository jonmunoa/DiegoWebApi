using DiegoWebApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoWebApi.Models
{
    public class OrderOptionsDto
    {
        public OrderOptionsEnum Id { get; set; }
        public string OrderType { get; set; }
    }
}