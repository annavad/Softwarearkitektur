using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;

public class User 
{
    public int UserId { get; set; }
    public string? Name { get; set; }
}