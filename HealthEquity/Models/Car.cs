using System;
using System.Collections.Generic;

namespace HealthEquity.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public int Doors { get; set; }

    public string Color { get; set; } = null!;

    public double Price { get; set; }
}
