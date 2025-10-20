﻿using BookStore.Abstactions;
using BookStore.BookStore.DataAccess;
using BookStore.BookStore.DataAccess.Entites;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookStoreDbContext _context;

    public BookRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetBooks()
    {
        var bookEntities = await _context.Books.AsNoTracking().ToListAsync();
        var books = bookEntities.Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book).ToList();
        return books;
    }
    public async Task<Guid> Create(Book book)
    {
        var bookEntity = new BookEntity
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Price = book.Price
        };
        await _context.Books.AddAsync(bookEntity);
        await _context.SaveChangesAsync();
        return bookEntity.Id;
    }

    public Task<Book> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Book>> Get()
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Update(Guid id, string title, string description, decimal price)
    {
        await _context.Books.Where(b => b.Id == id).ExecuteUpdateAsync(s =>
            s.SetProperty(b => b.Title, b => title).SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Price, b => price));
        return id;
    }
    public async Task<Guid> Delete(Guid id)
    {
        await _context.Books.Where(b => b.Id == id).ExecuteDeleteAsync();
        return id;
    }
}