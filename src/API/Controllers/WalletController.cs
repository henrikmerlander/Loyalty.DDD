﻿using System.Threading.Tasks;
using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/wallet")]
    public class WalletController : Controller
    {
        private readonly IMediator _mediator;

        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateWallet command)
        {
            var commandResult = await _mediator.Send(command);

            return commandResult ? Ok() : (IActionResult)BadRequest();
        }

        [Route("accrue")]
        [HttpPost]
        public async Task<IActionResult> Accrue([FromBody]AccruePoints command)
        {
            var commandResult = await _mediator.Send(command);

            return commandResult ? Ok() : (IActionResult)BadRequest();
        }

        [Route("redeem")]
        [HttpPost]
        public async Task<IActionResult> Redeem([FromBody]RedeemPoints command)
        {
            var commandResult = await _mediator.Send(command);

            return commandResult ? Ok() : (IActionResult)BadRequest();
        }
    }
}
