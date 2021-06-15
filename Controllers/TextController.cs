using DiegoWebApi.Enums;
using DiegoWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        [Route("GetOrderOptions")]
        [HttpGet]
        public IActionResult GetOrderOptions()
        {
            IList<OrderOptionsDto> orderOptions = new List<OrderOptionsDto>()
            {
                new OrderOptionsDto() { Id = OrderOptionsEnum.AlphabeticAsc, OrderType = "AlphabeticAsc" },
                new OrderOptionsDto() { Id = OrderOptionsEnum.AlphabeticDesc, OrderType = "AlphabeticDesc" },
                new OrderOptionsDto() { Id = OrderOptionsEnum.LenghtAsc, OrderType = "LenghtAsc" }
            };

            return Ok(orderOptions);
        }

        [Route("GetText")]
        [HttpPost]
        public IActionResult GetText([FromBody] GetTextDto getTextDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }

            var textWords = getTextDto.TextToOrder.Split(' ');

            IList<string> orderedWords = new List<string>();

            switch (getTextDto.OrderOption)
            {
                case OrderOptionsEnum.AlphabeticAsc:
                    orderedWords = textWords.OrderBy(word => word).ToList();
                    break;

                case OrderOptionsEnum.AlphabeticDesc:
                    orderedWords = textWords.OrderByDescending(word => word).ToList();
                    break;

                case OrderOptionsEnum.LenghtAsc:
                    orderedWords = textWords.OrderBy(word => word.Length).ToList();
                    break;

                default:
                    return BadRequest("Invalid OrderOption");
            }

            return Ok(orderedWords);
        }

        [Route("GetStatistics")]
        [HttpGet]
        public IActionResult GetStatistics()
        {
            return Ok();
        }
    }
}