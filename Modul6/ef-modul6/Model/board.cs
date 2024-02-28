using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using Model;

namespace Model
{
    public class Board
    {
        public long BoardId { get; set; }
        public List<Todos> Todos { get; set; } = new List<Todos>();
    }
}