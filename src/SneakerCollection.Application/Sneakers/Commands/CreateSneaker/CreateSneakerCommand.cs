﻿using ErrorOr;
using MediatR;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Domain.SneakerAggregate;

namespace SneakerCollection.Application.Sneakers.Commands.CreateSneaker
{
    public record CreateSneakerCommand(
        string UserId,
        string Name,
        BrandCommand Brand,
        PriceCommand Price,
        double SizeUS,
        int Year,
        int Rate) : IRequest<ErrorOr<Sneaker>>;
}
