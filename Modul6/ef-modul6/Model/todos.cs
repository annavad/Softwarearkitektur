using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using Model;

namespace Model
{
    public class Todos
    {
        public int TodoId { get; set; }
        public User? User { get; set; }
    }
}