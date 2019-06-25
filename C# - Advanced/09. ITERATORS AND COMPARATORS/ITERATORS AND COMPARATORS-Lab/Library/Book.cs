﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class Book
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public List<string> Authors { get;private set; }

        public Book(string title,int year,params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();

        }

    }
}