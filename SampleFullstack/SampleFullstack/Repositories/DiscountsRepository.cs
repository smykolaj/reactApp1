﻿using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.DTOs.Post;
using Project.Models;
using Project.Repositories.Interfaces;
using Project.Services.Interfaces;

namespace Project.Repositories;

public class DiscountsRepository : IDiscountsRepository
{
    private readonly ProjectContext _context;

    public DiscountsRepository(ProjectContext context)
    {
        _context = context;
    }

    public async Task<Discount> AddDiscount(Discount newDiscount)
    {
        await _context.Discounts.AddAsync(newDiscount);
        await _context.SaveChangesAsync();
        return newDiscount;
    }

    public async Task<decimal> GetHighestDiscount()
    {
        var discounts = await _context
            .Discounts
            .Where(d => d.TimeEnd > DateTime.Now 
                        && d.TimeStart < DateTime.Now)
            .Select(d => d.Value)
            .ToListAsync(); // Moves the data to client-side

        return discounts.DefaultIfEmpty(0).Max();
    }
}