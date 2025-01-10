﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FlavorFusion.Data;
using Microsoft.AspNetCore.Identity;
using FlavorFusion.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurarea serviciilor pentru aplicație
builder.Services.AddRazorPages();

// Configurarea contextului pentru baza de date FlavorFusion
builder.Services.AddDbContext<FlavorFusionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlavorFusionContext") ??
        throw new InvalidOperationException("Connection string 'FlavorFusionContext' not found.")));


var app = builder.Build();

// Configurarea pipeline-ului HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // HSTS în producție
}

app.UseHttpsRedirection(); // Redirecționarea HTTP către HTTPS
app.UseStaticFiles(); // Permite accesul la fișierele statice

app.UseRouting(); // Configurarea rutării

app.UseAuthorization(); // Activarea autorizării

app.MapRazorPages(); // Harta pentru paginile Razor

app.Run(); // Lansează aplicația
