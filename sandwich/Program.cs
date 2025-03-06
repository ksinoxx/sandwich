using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

List<Sandwich> repo = [];

app.MapGet("/", () => repo);
app.MapPost("/",(Sandwich dto)  =>  repo.Add(dto));
app.MapPut("/", ([FromQuery] Guid id, UpdateSandwichDTO dto) => 
{
    Sandwich buffer = repo.Find(s => s.Id == id);
    if (buffer == null)
    {
        return Results.NotFound();
    }
    buffer.Bread = dto.bread;
    buffer.Ñheese = dto.cheese;
    buffer.Meat = dto.meat;
    buffer.Salad = dto.salad;
    buffer.Sauce = dto.sause;
    buffer.Supplement = dto.supplement;
    buffer.Supplement2 = dto.suplement2;
    return Results.Json(buffer);
});
app.MapDelete("/", ([FromQuery] Guid id) => 
{
    Sandwich buffer = repo.Find(s => s.Id == id);
    repo.Remove(buffer);
});
app.Run();



public class Sandwich 
{
    public Guid Id { get; set; }
    public string? Bread { get; set; } = "null";
    public string? Cheese { get; set; } = "null";
    public string? Meat { get; set; } = "null";
    public string? Salad { get; set; } = "null";
    public string? Vegetables { get; set; } = "null";
    public string? Sauce { get; set; } = "null";
    public string? Supplement { get; set; } = "null";
    public string? Supplement2 { get; set; } = "null";
    public DateOnly DateNow { get; set; }
};

record class UpdateSandwichDTO (string bread, string cheese, string meat, string salad, string vegetables, string sause, string supplement, string suplement2);
