﻿using BrighterBins.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE
{
    public static class Database
    {
        static private List<User> _users = new List<User>();
        static private List<Bin> _bins = new List<Bin>();
        static Database()
        {
            Seed();
        }

        public static List<Bin> Bins { get => _bins; private set => _bins = value; }
        public static List<User> Users { get => _users; set => _users = value; }

        private static void Seed()
        {
            _users = new List<User>()
            {
                new User() { Id = Guid.NewGuid().ToString(), Email = "usman.azam173@gmail.com", Password= "123" },
                new User() { Id = Guid.NewGuid().ToString(), Email = "shahid.iqbal@gmail.com", Password= "123" },
                new User() { Id = Guid.NewGuid().ToString(), Email = "xs2khizerr@gmail.com", Password= "123" },
                new User() { Id = Guid.NewGuid().ToString(), Email = "naveed.ali@gmail.com", Password= "123" },
            };

            Random rnd = new Random();
            _bins = new List<Bin>();
            for (int i=0; i <30; i++)
            {
                var bin = new Bin() { 
                    Id = Guid.NewGuid().ToString(), 
                    Name = string.Format("Bin# {0}", rnd.Next(1,50)), 
                    FillLevel = rnd.Next(1, 200), 
                    Lat = 50d + rnd.Next(516400146, 630304598) / 1000000000d, 
                    Long = 4d - rnd.Next(224464416, 341194152) / 1000000000d
                };
                for(int j =0; j < rnd.Next(1, 15); j++)
                {
                    bin.Messages.Add(new Message()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Time = rnd.Next(1, 60),
                        Fill = rnd.Next(1, 200),
                    });
                }
                _bins.Add(bin);
            }
            
        }
    }
}