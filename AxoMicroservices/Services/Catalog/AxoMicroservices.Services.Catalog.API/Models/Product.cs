﻿namespace AxoMicroservices.Services.Catalog.API.Models;

public class Product    
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public List<string> Categories { get; set; } = new();
    public string Description { get; set; } = "";
    public string ImageFile { get; set; } = "";
    public decimal Price { get; set; }
}