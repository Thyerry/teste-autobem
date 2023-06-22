﻿using Bogus;
using Bogus.Extensions.Brazil;
using Entities.Entities;

namespace Tests.Fixture;

public static class OwnerFixture
{
    public static List<Owner> GenerateOwners(int qtd)
    {
        var owners = new Faker<Owner>()
            .RuleFor(o => o.Id, f => Guid.NewGuid())
            .RuleFor(o => o.Name, f => f.Name.FullName())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Cpf, f => f.Person.Cpf())
            .RuleFor(o => o.CNH, f => f.Person.Cpf())
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.BirthDate, f => RuleForDates(f))
            .RuleFor(o => o.InclusionDate, f => RuleForDates(f))
            .RuleFor(o => o.LastChange, f => RuleForDates(f));
            
        return owners.Generate(qtd);
    }
    private static DateTime RuleForDates(Faker f)
    {
        var date = f.Date.PastDateOnly();
        return new DateTime(date.Year, date.Month, date.Day).ToUniversalTime();
    }
}