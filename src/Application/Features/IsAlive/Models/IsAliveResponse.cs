using System;

namespace Elsekily.Application.Features.IsAlive.Models;

public class IsAliveResponse
{
    public string Status { get; set; }
    public DateTime Time { get; set; }
}
