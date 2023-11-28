using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticalPattern.ValueObjects;

public sealed class Customer //Rich Domain Model
{
    public Customer(CusomerId ıd, Name name, Lastname lastname, Address address, Money price)
    {
        Id = ıd;
        Name = name;
        Lastname = lastname;
        Address = address;
        Price = price;
    }

    public CusomerId Id { get; private set; }
    public Name Name { get; private set; }
    public Lastname Lastname { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
}

//strongly ID
public sealed record CusomerId(Guid Value);
public sealed record Name(string Value);
public sealed record Lastname(string Value);

public sealed record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money first, Money second)
    {
        if (first.Currency != second.Currency)
        {
            throw new ArgumentException("Para birimleri aynı olmalıdır!");
        }

        return new(first.Amount + second.Amount, first.Currency);
    }

    public static Money Zero() => new(0, Currency.None);
    public static Money Zero(Currency currency) => new(0, currency);

    public bool IsZero() => this == Zero(Currency);
}

public sealed record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Try = new("TRY");
    public static readonly Currency Euro = new("EURO");
    public string Code { get; init; }

    private Currency(string code)
    {
        Code = code;
    }

    private static readonly IReadOnlyCollection<Currency> All = new[] { Usd, Try, Euro };

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(p => p.Code == code) ??
            throw new ArgumentException("Girdiğiniz para birimi desteklenmiyor!");
    }
}

public sealed record Address(
    string Country,
    string City,
    string PhoneNumber,
    string FullAddress);