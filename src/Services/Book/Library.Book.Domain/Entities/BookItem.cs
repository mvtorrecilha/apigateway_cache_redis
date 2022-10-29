﻿namespace Library.Book.Domain.Entities;

public class BookItem
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public int Pages { get; set; }

    public string Publisher { get; set; }
}
