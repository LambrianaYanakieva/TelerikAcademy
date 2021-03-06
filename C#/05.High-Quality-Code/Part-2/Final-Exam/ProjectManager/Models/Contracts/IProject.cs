﻿namespace ProjectManager.Models
{
    using System;
    using System.Collections.Generic;

    public interface IProject
    {
        string Name { get; set; }

        DateTime StartingDate { get; set; }

        DateTime EndingDate { get; set; }

        string State { get; set; }

        List<User> Users { get; set; }

        List<Task> Tasks { get; set; }
    }
}
