﻿using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IPublisherService
    {
        IList<Publisher> GetPublishers();
    }
}
