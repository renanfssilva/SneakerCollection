﻿using SneakerCollection.Domain.Common.Models;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Domain.SneakerAggregate
{
    public sealed class Sneaker : AggregateRoot<SneakerId, Guid>
    {
        public string Name { get; private set; }
        public Brand Brand { get; private set; }
        public Price Price { get; private set; }
        public double SizeUS { get; private set; }
        public int Year { get; private set; }
        public int Rate { get; private set; }
        public UserId UserId { get; private set; }

        private Sneaker(SneakerId sneakerId,
            string name,
            Brand brand,
            Price price,
            double sizeUS,
            int year,
            int rate,
            UserId userId) : base(sneakerId)
        {
            Name = name;
            Brand = brand;
            Price = price;
            SizeUS = sizeUS;
            Year = year;
            Rate = rate;
            UserId = userId;
        }

        public static Sneaker Create(
            string name,
            Brand brand,
            Price price,
            double sizeUS,
            int year,
            int rate,
            UserId userId)
        {
            return new Sneaker(
                SneakerId.CreateUnique(),
                name,
                brand,
                price,
                sizeUS,
                year,
                rate,
                userId);
        }

        public static Sneaker Update(
            SneakerId sneakerId,
            string name,
            Brand brand,
            Price price,
            double sizeUS,
            int year,
            int rate,
            UserId userId)
        {
            return new Sneaker(
                sneakerId,
                name,
                brand,
                price,
                sizeUS,
                year,
                rate,
                userId);
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Sneaker()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
