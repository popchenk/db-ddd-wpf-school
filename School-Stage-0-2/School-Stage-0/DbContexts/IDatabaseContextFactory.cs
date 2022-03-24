using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.DbContexts
{
    public interface IDatabaseContextFactory
    {

        IDatabaseContext Context();

    }
}
