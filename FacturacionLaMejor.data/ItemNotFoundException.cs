﻿using System;

namespace FacturacionLaMejor.data
{
    public class ItemNotFoundException<T> : Exception
    {
        public ItemNotFoundException(long id)
        {
            throw new NotImplementedException();
        }

        public ItemNotFoundException()
        {
            throw new NotImplementedException();
        }
    }
}