﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PNN.Web.Data.Entities;

namespace PNN.web.Data.Entities
{ 
public class Manager
	{
		public int Id { get; set; }

		public User User { get; set; }

		public ICollection<Park> Parks { get; set; }
		public ICollection<Zone> Zones { get; set; }
	}
}
