﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FluentApiLesson.Models
{

    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
