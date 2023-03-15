﻿using API.DTOs.Reservations;
using Application.Reservations.Commands.CreateReservation;
using Application.Reservations.Queries.GetReservations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ReservationController(
            IMapper mapper, 
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a reservation
        /// </summary>
        /// <response code="201">Reservation successfully created</response>
        /// <response code="409">Reservation for the requested table and date already exists.\
        ///                      Requested time is less than current time.
        /// </response>
        [HttpPost]
        [ProducesResponseType(typeof(ReservationGetModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public async Task<ReservationGetModel> CreateReservation(ReservationPostModel request)
        {
            var command = _mapper.Map<CreateReservationCommand>(request);

            var result = await _mediator.Send(command);
            return _mapper.Map<ReservationGetModel>(result);
        }

        /// <summary>
        /// Get list of reservation from today's date grouped by table number
        /// </summary>
        /// <response code="200">Reservations successfully retrieved</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReservationByTableGetModel>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<ReservationByTableGetModel>> GetReservations()
        {
            var query = new GetReservationsQuery();

            var result = await _mediator.Send(query);
            return _mapper.Map<IEnumerable<ReservationByTableGetModel>>(result);
        }
    }
}
